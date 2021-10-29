using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BlockBase : MonoBehaviour
{
    // 未购买成功块
    [SerializeField] public CanvasGroup noCheckSignCanvasGroupnon;
    // 购买成功块
    [SerializeField] public CanvasGroup checkSignCanvasGroup;

    // 是否购买
    private bool isBuy = false;

    /// <summary>
    /// 进行默认初始化，让该显示的模块进行显示，该隐藏的模块进行隐藏
    /// </summary>
    public void Start()
    {
        noCheckSignCanvasGroupnon.alpha = 1;
        checkSignCanvasGroup.alpha = 0;
    }

    /// <summary>
    /// 当购买按钮按下后，进行UI反馈
    /// </summary>
    public void OnBuyButtonClick()
    {
        if (isBuy) return;
        isBuy = true;

        noCheckSignCanvasGroupnon.DOFade(0f, 0.5f);
        checkSignCanvasGroup.DOFade(1f, 0.5f);
    }
}