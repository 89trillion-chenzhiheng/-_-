using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FreeBlock : BlockBase
{
    // 图标显示的UI
    [SerializeField] public Image showIcon;
    // 图标集合
    [SerializeField] public List<Sprite> cardIcons;

    /// <summary>
    /// 设置免费块的类型显示
    /// </summary>
    /// <param name="type">要显示的类型</param>
    public void SetFreeBlockIcon(RewardType type)
    {
        int index = 0; // 默认值为0

        switch (type)
        {
            case RewardType.Coins: // 图标集合的第0位为金币图标
                index = 0;
                break;
            case RewardType.Diamonds:// 图标集合的第1位为钻石图标
                index = 1;
                break;
            default:
                break;
        }

        showIcon.sprite = cardIcons[index]; // 设置图标显示
    }
}
