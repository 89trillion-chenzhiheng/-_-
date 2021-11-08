using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUIShow : MonoBehaviour
{
    // 天数显示
    [SerializeField] private Text dayShow;
    // 小时显示
    [SerializeField] private Text hourShow;
    // 分钟显示
    [SerializeField] private Text minuteShow;
    // 秒显示
    [SerializeField] private Text secondShow;


    /// <summary>
    /// 开始记时UI显示
    /// </summary>
    public void StartRefreshTimeShow()
    {

        // 注册刷新时间事件
        GameMessageModel.TimeModel.OnTimeRefreshClick += RefreshTimeShow;
        RefreshTimeShow(GameMessageModel.TimeModel);
    }

    /// <summary>
    /// 停止记时UI显示
    /// </summary>
    public void StopRefreshTimeShow()
    {
        // 注销刷新时间事件
        GameMessageModel.TimeModel.OnTimeRefreshClick -= RefreshTimeShow;
    }

    /// <summary>
    /// 刷新时间显示
    /// </summary>
    /// <param name="time">时间</param>
    private void RefreshTimeShow(TimeModel time)
    {
        dayShow.text = (time.day < 10 ? "0" : "") + time.day.ToString() + 'd';
        hourShow.text = (time.hour < 10 ? "0" : "") + time.hour.ToString() + 'h';
        minuteShow.text = (time.minute < 10 ? "0" : "") + time.minute.ToString() + 'm';
        secondShow.text = (time.second < 10 ? "0" : "") + time.second.ToString() + 's';
    }
}
