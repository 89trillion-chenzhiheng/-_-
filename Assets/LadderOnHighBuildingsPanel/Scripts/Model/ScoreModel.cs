using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModel
{
    /// <summary>
    /// 分数修改事件
    /// </summary>
    public VoidIntFunction OnScoreChallengeClick;
    /// <summary>
    /// 赛季刷新事件
    /// </summary>
    public VoidIntFunction OnSeasonRefreshClick;

    // 当前的分数
    private int score;
    // 引用天梯界面
    private LadderOnHighBuildingsPanel ladderOnHighBuildingsPanel;


    public ScoreModel(LadderOnHighBuildingsPanel ladderOnHighBuildingsPanel, int score)
    {
        // 赋予初始值
        this.score = score;
        this.ladderOnHighBuildingsPanel = ladderOnHighBuildingsPanel;
    }

    /// <summary>
    /// 获取或修改分数
    /// </summary>
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            ChangeScore(value);
        }
    }

    /// <summary>
    /// 赛季刷新
    /// </summary>
    public void SeasonRefresh()
    {
        ChangeScore(score);

        OnScoreChallengeClick?.Invoke(score);
    }

    /// <summary>
    /// 修改分数
    /// </summary>
    /// <param name="score">修改后的分数</param>
    private void ChangeScore(int score)
    {
        this.score = score;
        this.score = Mathf.Clamp(this.score, 0, 6000);

        // 分数改变事件触发
        OnScoreChallengeClick?.Invoke(this.score);
    }
}
