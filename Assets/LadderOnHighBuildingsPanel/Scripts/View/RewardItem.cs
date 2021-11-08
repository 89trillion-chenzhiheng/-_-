using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardItem : MonoBehaviour
{
    // 领取状态显示文本
    [SerializeField] private Text receiveStateShowText;
    // 引用天梯界面
    [SerializeField] private LadderOnHighBuildingsPanel ladderOnHighBuildingsPanel;

    // 是否被领取
    private bool isReceive = false;

    public void Awake()
    {
        receiveStateShowText.text = "可领取";
    }

    /// <summary>
    /// 当奖励领取按钮被按下
    /// </summary>
    public void OnReceiveBtnClick()
    {
        // 没有被领取则进行领取后的反馈：添加金币，UI显示
        if (!isReceive) 
        {
            isReceive = true;

            receiveStateShowText.text = "已领取";

            ladderOnHighBuildingsPanel.coinModel.Coin += 100;
        }
    }
}
