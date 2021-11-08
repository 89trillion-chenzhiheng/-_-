using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Card : BlockBase
{
    // 购买该卡片中的商品需要花费的金额
    [SerializeField] public Text costAmount;
    // 购买该卡片中的商品需要花费的货币类型显示
    [SerializeField] public Image cardIconShowImage;
    // 卡片内商品的图标集合
    [SerializeField] public List<Sprite> cardIcons;

    /// <summary>
    /// 根据类型设置图标的显示
    /// </summary>
    public void Start()
    {
        int type = GameManager.Instance.ObjHashTypeMessage(gameObject);
        // 默认为0，避免没有该类型的时候数组越界
        int index = 0;
        // 根据类型更改图标集合的索引
        switch (type)
        {
            case 13:
                index = 1;
                break;
            case 18:
                index = 2;
                break;
            case 20:
                index = 3;
                break;
            default:
                break;
        }
        // 更改图标
        cardIconShowImage.sprite = cardIcons[index];
    }

    /// <summary>
    /// 设置需要花费的金额
    /// </summary>
    /// <param name="amount">金额</param>
    public void SetCostAmount(int amount)
    {
        costAmount.text = amount.ToString();
    }
}
