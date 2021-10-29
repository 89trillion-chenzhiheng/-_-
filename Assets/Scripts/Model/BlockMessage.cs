using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BlockMessage
{
    // 商品ID
    public int productID;
    // 商品父类型
    public RewardType type;
    // 商品子类型
    public RewardType subType;
    // 商品数量
    public int num;
    // 需花费多少金币
    public int costGold;
    // 需花费多少钻石
    public int costGem;
    // 是否已经购买
    public bool isPurchased;
}
