using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinModel
{
    /// <summary>
    /// 金币修改事件
    /// </summary>
    public VoidIntFunction OnCoinChallengeClick;

    // 当前的金币
    private int coin;

    public CoinModel(int coin)
    {
        // 赋予初始值
        this.coin = coin;
    }

    /// <summary>
    /// 获取或修改金币
    /// </summary>
    public int Coin
    {
        get
        {
            return coin;
        }
        set
        {
            coin = value;

            // 金币改变事件触发
            OnCoinChallengeClick?.Invoke(this.coin);
        }
    }
}
