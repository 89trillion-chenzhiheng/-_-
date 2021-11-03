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
                GetGameMessageModel();
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
            // 如果还没有获取，就去获取
            if (actorModels == null)
            {
                GetGameMessageModel();
            }
            return actorModels;
        }
    }

    /// <summary>
    /// 从Json文件中解析数据
    /// </summary>
    private static void GetGameMessageModel()
    {
        timeModel = new TimeModel();
        timeModel.SetTime(JsonRead.GetTimeData());
        actorModels = JsonRead.GetActorModels();

        // 如果没有排序则进行排序
        if(!isActorModelSort)
        {
            isActorModelSort = true;
            SortActorModelByTrophy(0, actorModels.Count - 1);
        }
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
