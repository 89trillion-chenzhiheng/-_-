using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreTitle : MonoBehaviour
{
    // 金币数量显示的UI
    [SerializeField]
    public Text coinShowText;
    // 钻石数量显示的的UI
    [SerializeField]
    public Text diamondShowText; 

    /// <summary>
    /// 获取或者修改当前金币的数量
    /// 减少其他地方频繁的使用类型转换，调用该方法可以返回转换后的数据
    /// 增加判断金额为负数的情况
    /// </summary>
    public int CoinAmount
    {
        get
        {
            // 返回类型转换后的数据
            return int.Parse(coinShowText.text);
        }
        set
        {
            // 数据最小为0
            if (value < 0)
            {
                value = 0;
            }
            // 更新金币数量显示
            coinShowText.text = value.ToString();
        }
    }

    /// <summary>
    /// 获取或者修改当前钻石的数量
    /// 减少其他地方频繁的使用类型转换，调用该方法可以返回转换后的数据
    /// 增加判断金额为负数的情况
    /// </summary>
    public int DiamondAmount
    {
        get
        {
            // 返回类型转换后的数据
            return int.Parse(diamondShowText.text);
        }
        set
        {
            // 数据最小为0
            if (value < 0)
            {
                value = 0;
            }
            // 更新钻石数量显示
            diamondShowText.text = value.ToString();
        }
    }
}
