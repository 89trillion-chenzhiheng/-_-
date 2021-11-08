using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingListPanel : MonoBehaviour
{
    // 计时器UI显示对象
    public TimeUIShow timeUIShow;
    // Toast界面对象
    public ToastShowMessage toastShowMessage;

    /// <summary>
    /// 打开界面按钮按下
    /// </summary>
    public void OpenButtonClick()
    {
        GameMessageModel.CreateAndSendRankListRequest(delegate
        {
            // 将面板显示
            gameObject.SetActive(true);
            // 开始刷新时间UI显示
            timeUIShow.StartRefreshTimeShow();
            // 开始记时
            GameMessageModel.TimeModel.StartTimeKeeping();
        });
    }

    /// <summary>
    /// 关闭界面按钮按下
    /// </summary>
    public void CloseButtonClick()
    {
        // 将面板隐藏
        gameObject.SetActive(false);
        // 暂停刷新时间UI显示
        timeUIShow.StopRefreshTimeShow();
    }
}
