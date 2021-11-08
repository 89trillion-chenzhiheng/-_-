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
    // 角色信息是否被排序
    private static bool isActorModelSort = false;
    // 获取数据之后的回调
    private static Action HTTPCallBack;

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
    public static void CreateAndSendRankListRequest(Action callBack)
    {
        // 获取数据之后的回调
        HTTPCallBack = callBack;
        // 创建新的请求排行榜的请求
        RankAPIManager rankAPIManager = new RankAPIManager();
        // 发送请求
        rankAPIManager.RequestNewRankList(new GameObject(), GetActorModelsByHTTP);
    }

    /// <summary>
    /// 通过HTTP获取信息数据
    /// </summary>
    public static void GetActorModelsByHTTP(string data)
    {
        // 解析数据
        actorModels = JsonRead.GetActorModels(data);

        // 如果没有排序则进行排序
        if (!isActorModelSort)
        {
            isActorModelSort = true;
            SortActorModelByTrophy(0, actorModels.Count - 1);
        }

        HTTPCallBack?.Invoke();
    }

    /// <summary>
    /// 排序角色信息按照奖杯数量
    /// 快排算法
    /// </summary>
    private static void SortActorModelByTrophy(int left, int right)
    {
        if (left < right)
        {
            ActorModel mid = actorModels[left];
            int leftIndex = left, rightIndex = right;

            while (left < right)
            {
                while (left < right && actorModels[right].trophy <= mid.trophy)
                {
                    right--;
                }
                actorModels[left] = actorModels[right];
                while (left < right && actorModels[left].trophy >= mid.trophy)
                {
                    left++;
                }
                actorModels[right] = actorModels[left];
            }

            actorModels[left] = mid;

            SortActorModelByTrophy(leftIndex, left - 1);
            SortActorModelByTrophy(left + 1, rightIndex);
        }
    }
}
