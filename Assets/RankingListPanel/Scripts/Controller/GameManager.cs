using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 单例模式，提供了无需继承MonoBehaviour但要使用一部分MonoBehaviour的方法如协程
/// </summary>
public sealed class GameManager : MonoBehaviour
{
    // 背景图片集合
    public Sprite[] backgroundSprites;
    // 段位等级图片集合
    public Sprite[] segmentPositionIconSprites;
    // 前三名图标集合
    public Sprite[] rankingIconSprites;
    // 排行榜面板的引用
    public RankingListPanel rankingListPanel;

    // 获取自身，单例模式
    private static GameManager instance;

    // 获取该脚本
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }


    public void Awake()
    {
        // 给单例模式默认初始值
        instance = this;
    }
}
