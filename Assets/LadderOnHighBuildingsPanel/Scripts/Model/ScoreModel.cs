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
    // 多长时间刷新一次分数
    private float time;
    // 引用天梯界面
    private LadderOnHighBuildingsPanel ladderOnHighBuildingsPanel;
    // 等待一段时间去添加分数的协程
    private Coroutine waitTimeToAddScore;

    public ScoreModel(LadderOnHighBuildingsPanel ladderOnHighBuildingsPanel, int score, float time)
    {
        // 赋予初始值
        this.score = score;
        this.time = time;
        this.ladderOnHighBuildingsPanel = ladderOnHighBuildingsPanel;

        // 开始加分
        waitTimeToAddScore = this.ladderOnHighBuildingsPanel.StartCoroutine(WaitTimeToAddScore(time));
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

    /// <summary>
    /// 等待一段时间去添加分数
    /// </summary>
    /// <param name="time">等待时间</param>
    /// <returns></returns>
    private IEnumerator WaitTimeToAddScore(float time)
    {
        while(true)
        {
            // 等待一段时间，需要避免游戏暂停的情况：游戏暂停，分数依然在增加
            yield return new WaitForSecondsRealtime(time);

            // 添加分数
            ChangeScore(score + 1);
        }
    }

    /// <summary>
    /// 析构函数，将开启的协程关闭
    /// </summary>
    ~ScoreModel()
    {
        ladderOnHighBuildingsPanel.StopCoroutine(waitTimeToAddScore);
    }
}
