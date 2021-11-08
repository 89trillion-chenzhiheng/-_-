using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LadderOnHighBuildingsPanel : MonoBehaviour
{
    // 初始分数
    [SerializeField] private int startScore;
    // 等待多长时间去加分数
    [SerializeField] private float waitToAddScoreTime;
    // 初始金币
    [SerializeField] private int startCoin;
    // 分数显示文本
    [SerializeField] private Text scoreShowText;
    // 金币显示文本
    [SerializeField] private Text coinShowText;
    // 段位图标显示
    [SerializeField] private Image segmentPositionIconImage;
    // 段位名称显示
    [SerializeField] private Text segmentPositionIconText;
    // 赛季名称显示
    [SerializeField] private Text competitionSeasonText;
    // 奖励预制体
    [SerializeField] private GameObject rewardItemPrefab;
    // 奖励预制体的父对象
    [SerializeField] private RectTransform rewardItemFriend;
    // 段位图标集合
    [SerializeField] private Sprite[] segmentPositionIconSprites;
    // 段位和奖励显示列表
    [SerializeField] private GameObject[] segmentAndRewardList;

    // 分数类
    [HideInInspector]
    public ScoreModel scoreModel;
    // 金币类
    [HideInInspector]
    public CoinModel coinModel;

    // 分数刷新前的分数
    private int lastScore = 0;
    // 当前赛季
    private int competitionSeason = 1;
    // 奖励集合
    private List<GameObject> rewardItems = new List<GameObject>();

    public void Awake()
    {
        // 实例化分数类
        scoreModel = new ScoreModel(this, startScore, waitToAddScoreTime);
        // 注册分数更改事件
        scoreModel.OnScoreChallengeClick += RefreshScoreText;
        // 显示分数
        RefreshScoreText(scoreModel.Score);

        // 实例化金币类
        coinModel = new CoinModel(startCoin);
        // 注册金币更改事件
        coinModel.OnCoinChallengeClick += RefreshCoinText;
        // 显示金币
        RefreshCoinText(coinModel.Coin);
    }

    /// <summary>
    /// 当加分按钮按下
    /// </summary>
    public void AddScoreClick()
    {
        lastScore = scoreModel.Score;

        scoreModel.Score += 100;
    }

    /// <summary>
    /// 当赛季刷新按钮按下
    /// </summary>
    public void SeasonRefreshClick()
    {
        // 赛季更新，UI显示更新
        competitionSeason++;
        competitionSeasonText.text = "赛季：" + competitionSeason.ToString();

        // 获取此刻的分数
        int score = scoreModel.Score;

        // 将4000以上的分数减去一半
        score = (score >= 4000) ? ((score - 4000) / 2 + 4000) : score;

        // 分数刷新
        scoreModel.Score = score;

        // 重置上次的分数
        lastScore = score;

        // 遍历所有的奖励并进行销毁
        while (rewardItems.Count > 0)
        {
            GameObject reward = rewardItems[0];
            rewardItems.Remove(reward);
            Destroy(reward);
        }

        for (int i = 4200; i <= scoreModel.Score; i += 200) 
        {
            if (i % 1000 != 0) 
            {
                CreateReward();
            }
        }

        // 刷新段位图标显示
        RefreshSegmentPositionIconShow();
    }

    /// <summary>
    /// 当查看段位按钮按下
    /// </summary>
    public void ViewSegmentClick()
    {
        foreach (var item in segmentAndRewardList)
        {
            item.SetActive(true);
        }
    }

    /// <summary>
    /// 当分数刷新时刷新分数显示
    /// </summary>
    /// <param name="score">分数</param>
    private void RefreshScoreText(int score)
    {
        scoreShowText.text = score.ToString();

        // 如果分数大于4000 && 分数跨越了200分 && 分数不是整千
        if(score > 4000 && (score / 200 != lastScore / 200) && ((score - score % 200) % 1000 != 0))
        {
            CreateReward();
        }

        // 刷新段位图标显示
        RefreshSegmentPositionIconShow();

        lastScore = score;
    }

    /// <summary>
    /// 创建奖励
    /// </summary>
    private void CreateReward()
    {
        // 实例化奖励并初始化，加入队列中
        GameObject reward = GameObject.Instantiate(rewardItemPrefab, rewardItemFriend);
        reward.SetActive(true);
        rewardItems.Add(reward);
    }

    /// <summary>
    /// 刷新段位图标显示
    /// </summary>
    private void RefreshSegmentPositionIconShow()
    {
        if(scoreModel.Score >= 4000)
        {
            segmentPositionIconText.gameObject.SetActive(true);
            segmentPositionIconText.text = "段位" + (scoreModel.Score / 1000 + 1).ToString();
        }
        else
        {
            segmentPositionIconText.gameObject.SetActive(false);
        }
        segmentPositionIconImage.sprite = segmentPositionIconSprites[scoreModel.Score / 1000];
        // 适应大小
        segmentPositionIconImage.SetNativeSize();
    }

    /// <summary>
    /// 当金币刷新时刷新金币显示
    /// </summary>
    /// <param name="score">金币</param>
    private void RefreshCoinText(int coin)
    {
        coinShowText.text = coin.ToString();
    }
}
