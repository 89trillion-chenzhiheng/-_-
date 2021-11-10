using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingListPanel : MonoBehaviour
{
    // 计时器UI显示对象
    [SerializeField] private TimeUIShow timeUIShow;
    // 加载提示文本
    [SerializeField] private Text loadingTitleText;
    // 打开界面按钮
    [SerializeField] private Button openPanelBtn;
    // 打开界面按钮
    [SerializeField] private string HTTPPath;
    // 打开界面按钮
    [SerializeField] private int HTTPType;
    // 打开界面按钮
    [SerializeField] private int HTTPPage;
    // 打开界面按钮
    [SerializeField] private int HTTPSeason;
    // 打开界面按钮
    [SerializeField] private string HTTPToken;
    // Toast界面对象
    public ToastShowMessage toastShowMessage;

    // 是否正在打开界面
    private bool isOpeningPanel = false;
    // 正在加载提示文本
    private string loadingTitle = "正在加载...";
    // 加载失败提示文本
    private string loadingError = "加载失败，请重新加载...";

    

    /// <summary>
    /// 当数据加载成功
    /// </summary>
    private void OnCreateAndSendRankListRequestSuccess()
    {
        // 将面板显示
        gameObject.SetActive(true);
        // 开始刷新时间UI显示
        timeUIShow.StartRefreshTimeShow();
        // 开始记时
        GameMessageModel.TimeModel.StartTimeKeeping();
        // 加载成功UI反馈
        OpenPanelLoadingFeedback(true);
    }

    /// <summary>
    /// 当数据加载失败
    /// </summary>
    private void OnCreateAndSendRankListRequestError(string msg, int code)
    {
        // 加载失败UI反馈
        OpenPanelLoadingFeedback(false);
    }

    /// <summary>
    /// 打开界面反馈UI显示
    /// </summary>
    private void OpenPanelLoadingFeedback(bool success)
    {
        // 如果加载失败，则显示失败按钮
        if (!success)
        {
            loadingTitleText.text = loadingError;
        }
        // 加载文本隐藏
        loadingTitleText.enabled = !success;
        // 加载按钮关闭
        openPanelBtn.gameObject.SetActive(!success);
        // 加载完成
        isOpeningPanel = false;
    }

    #region PanelOpenOrCloseFunction

    /// <summary>
    /// 打开界面按钮按下
    /// </summary>
    public void OpenPanelButtonClick()
    {
        // 如果正在打开就无须重复打开，避免多次请求HTTP
        if (isOpeningPanel)
        {
            return;
        }

        // 正在打开界面
        isOpeningPanel = true;

        // 如果没有数据则通过HTTP请求数据
        if (GameMessageModel.ActorModels == null)
        {
            // 正在打开界面提示文本显示
            loadingTitleText.text = loadingTitle;
            loadingTitleText.enabled = true;

            // 申请HTTP调用
            GameMessageModel.CreateAndSendRankListRequest(HTTPPath, HTTPType, HTTPPage, HTTPSeason, HTTPToken, OnCreateAndSendRankListRequestSuccess, OnCreateAndSendRankListRequestError);
        }
        else
        {
            // 已经存在数据，只需加载数据反馈即可，无需重新申请HTTP
            OnCreateAndSendRankListRequestSuccess();
        }
    }

    /// <summary>
    /// 关闭界面按钮按下
    /// </summary>
    public void ClosePanelButtonClick()
    {
        // 将面板隐藏
        gameObject.SetActive(false);
        // 暂停刷新时间UI显示
        timeUIShow.StopRefreshTimeShow();
        // 加载按钮打开
        openPanelBtn.gameObject.SetActive(true);
    }

    #endregion
}
