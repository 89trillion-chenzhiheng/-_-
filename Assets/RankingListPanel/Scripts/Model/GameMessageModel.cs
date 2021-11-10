using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameMessageModel
{
    // 时间对象
    private static TimeModel timeModel;
    // 所有角色信息对象
    private static List<ActorModel> actorModels;
    // 请求成功的回调
    private static Action HTTPSuccessCallBack;
    // 请求失败的回调
    private static Action<string, int> HTTPErrorCallBack;

    /// <summary>
    /// 获取时间类
    /// </summary>
    public static TimeModel TimeModel
    {
        get
        {
            // 如果还没有获取，就去获取
            if(timeModel == null)
            {
                // 返回默认值：2048
                timeModel = new TimeModel();
                timeModel.SetTime("2048");
            }
            return timeModel;
        }
    }

    /// <summary>
    /// 获取所有角色信息
    /// </summary>
    public static List<ActorModel> ActorModels
    {
        get
        {
            return actorModels;
        }
    }

    /// <summary>
    /// 创建并发送获取排行榜请求
    /// </summary>
    public static void CreateAndSendRankListRequest(string path, int type, int page, int season, string token,
        Action requestSuccessCallBack,
        Action<string, int> requestErrorCallBack)
    {
        // 获取数据之后的回调
        HTTPSuccessCallBack = requestSuccessCallBack;
        // 获取失败之后的回调
        HTTPErrorCallBack = requestErrorCallBack;
        // 创建新的请求排行榜的请求
        RankAPIManager rankAPIManager = new RankAPIManager();
        // 发送请求
        rankAPIManager.RequestNewRankList(GameManager.Instance.gameObject, path, type, page, season, token, GetActorModelsByHTTPSuccess, GetActorModesByHTTPError, GetActorModesByHTTPCacheRestore);
    }

    #region InteractiveCallBack

    /// <summary>
    /// 服务端排行榜数据修改事件
    /// </summary>
    /// <param name="data">数据</param>
    private static void GetActorModesByHTTPCacheRestore(string data)
    {
        // 对数据进行解析和排序
        DataAnalysisAndSort(data);
    }

    /// <summary>
    /// 通过HTTP获取数据成功
    /// </summary>
    private static void GetActorModelsByHTTPSuccess(string data)
    {
        // 对数据进行解析和排序
        DataAnalysisAndSort(data);

        // 获取数据成功事件触发
        HTTPSuccessCallBack?.Invoke();
    }

    /// <summary>
    /// 通过HTTP获取数据失败
    /// </summary>
    private static void GetActorModesByHTTPError(string msg, int code)
    {
        HTTPErrorCallBack?.Invoke(msg, code);
    }

    /// <summary>
    /// 对下载后的数据进行解析和排序
    /// </summary>
    private static void DataAnalysisAndSort(string data)
    {
        // 解析数据
        List<ActorModel> actors = JsonRead.GetActorModels(data);

        // 数据按照奖杯数量进行排序
        SortActorModelByTrophy(actors, 0, actors.Count - 1);

        // 刷新数据
        actorModels = actors;
    }

    #endregion

    /// <summary>
    /// 排序角色信息按照奖杯数量
    /// 快排算法
    /// </summary>
    private static void SortActorModelByTrophy(List<ActorModel> models, int left, int right)
    {
        if (left < right)
        {
            ActorModel mid = models[left];
            int leftIndex = left, rightIndex = right;

            while (left < right)
            {
                while (left < right && models[right].trophy <= mid.trophy)
                {
                    right--;
                }
                models[left] = models[right];
                while (left < right && models[left].trophy >= mid.trophy)
                {
                    left++;
                }
                models[right] = models[left];
            }

            models[left] = mid;

            SortActorModelByTrophy(models, leftIndex, left - 1);
            SortActorModelByTrophy(models, left + 1, rightIndex);
        }
    }
}
