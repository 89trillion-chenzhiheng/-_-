using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TimeModel
{
    // 天
    public int day;
    // 时
    public int hour;
    // 分
    public int minute;
    // 秒
    public int second;

    // 当刷新时间时
    public VoidTimeModelFunction OnTimeRefreshClick;

    // 更新时间的协程
    private Coroutine refreshTimeCorotine = null;
    // 上次计时的时间
    private float lastTime = 0f;

    /// <summary>
    /// 设置时间
    /// </summary>
    /// <param name="time">时间</param>
    public void SetTime(string time)
    {
        // 一天有多少秒
        long dayTime = 86400L;

        // 时间转格式
        long timeL = long.Parse(time);

        // 设置天
        day = (int)(timeL / dayTime);
        timeL %= dayTime;
        dayTime /= 24;

        // 设置时
        hour = (int)(timeL / dayTime);
        timeL %= dayTime;
        dayTime /= 60;

        // 设置分
        minute = (int)(timeL / dayTime);
        timeL %= dayTime;
        dayTime /= 60;

        // 设置秒
        second = (int)timeL;

        // 刷新时间事件触发
        OnTimeRefreshClick?.Invoke(this);
    }

    /// <summary>
    /// 开始记时
    /// </summary>
    public void StartTimeKeeping()
    {
        // 开始记时
        if (refreshTimeCorotine != null)
            GameManager.Instance.StopCoroutine(refreshTimeCorotine);
        refreshTimeCorotine = GameManager.Instance.StartCoroutine(RefreshTime());
    }

    /// <summary>
    /// 更新时间
    /// </summary>
    /// <returns></returns>
    private IEnumerator RefreshTime()
    {
        while (day != 0 || hour != 0 || minute != 0 || second != 0)
        {
            yield return new WaitForSeconds(0.5f);

            // 更新时间
            float time = Time.time;
            if(time - lastTime >= 1f)
            {
                lastTime = time;

                if(second != 0)
                {
                    second--;
                }
                else if(minute != 0)
                {
                    minute--;
                    second = 59;
                }
                else if(hour != 0)
                {
                    hour--;
                    minute = 59;
                    second = 59;
                }
                else if(day != 0)
                {
                    day--;
                    hour = 59;
                    minute = 59;
                    second = 59;
                }

                OnTimeRefreshClick?.Invoke(this);
            }
        }
    }
}
