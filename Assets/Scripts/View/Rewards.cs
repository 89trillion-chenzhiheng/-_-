using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Rewards : MonoBehaviour
{
    [Header("金币生成时间间隔")]
    [SerializeField]
    public float createInterval = 0.1f;
    [Header("金币飞行时间")]
    [SerializeField]
    public float flyTime = 1f;
    [Header("金币生成到飞行之间的时间间隔")]
    [SerializeField]
    public float startFlyTime = 0.3f;
    // 金币生成之后的父对象，避免随意生成在Hierarchy上特别混乱
    [SerializeField]
    public RectTransform coinFriend;
    // 金币飞行的起点
    [SerializeField]
    public RectTransform coinStartPos;
    // 金币飞行的终点
    [SerializeField]
    public RectTransform coinEndPos;
    // 金币的Prefab
    [SerializeField]
    public GameObject coinPrefab;
    // 商店的引用，用于更新金币
    [SerializeField]
    public StorePanel storePanel;

    // 是否在播放金币动画
    private bool isPlay = false;
    // 第几次点击
    private int clickNum = 0;
    // 金币池
    private List<RectTransform> coins = new List<RectTransform>(); 

    /// <summary>
    /// 当宝箱被打开
    /// </summary>
    public void OnRewardsOpen()
    {
        // 如果正在播放金币飞行特效，则不进行任何操作
        if(isPlay)
        {
            return;
        }
        // 开始金币飞行特效
        isPlay = true;

        // 点击次数不可以大于3，目的是每次点击金币增加5个，总金币不可以大于15
        clickNum = clickNum + 1 > 3 ? 3 : clickNum + 1; // clickNum不可以大于3

        // 每次点击金币数提升5个，最大为15个
        StartCoroutine(CreateCoin(clickNum * 5));
    }

    /// <summary>
    /// 金币特效动画
    /// </summary>
    /// <param name="num">金币数量</param>
    /// <returns></returns>
    private IEnumerator CreateCoin(int num)
    {
        // 循环创建金币
        for (int i = 0; i < num; i++) 
        {
            // 金币生成间隔时间
            yield return new WaitForSeconds(createInterval);

            // 更新金币数量 
            storePanel.storeTitle.CoinAmount += 1;
            // 金币实例设置为null，接下来判断是实例化还是从金币池中获取
            RectTransform coin = null;
            // 实例化金币
            if(i >= coins.Count)
            {
                coin = GameObject.Instantiate(coinPrefab, coinFriend, false).GetComponent<RectTransform>();
                // 金币加入金币池
                coins.Add(coin);
            }
            else
            {
                // 从金币池中读取
                coin = coins[i];
                // 金币池中的金币默认隐藏，需要将其打开
                coin.gameObject.SetActive(true);
            }
            // 设置金币的位置在飞行初始位置
            coin.position = coinStartPos.position;

            // 制作金币飞行动画序列
            Sequence sequence = DOTween.Sequence();
            // 获取终点坐标
            Vector3 endPos = coinEndPos.position;
            // 不是最后一个金币
            if(i != num - 1)
            {
                sequence.Insert(startFlyTime, coin.DOMove(endPos, flyTime)).OnComplete(delegate
                {
                    // 将金币隐藏掉
                    coin.gameObject.SetActive(false);
                });
            }
            // 是最后一个金币到达目的地，需要执行一些额外的操作
            else
            {
                sequence.Insert(startFlyTime, coin.DOMove(endPos, flyTime)).OnComplete(delegate
                {
                    // 将金币隐藏掉
                    coin.gameObject.SetActive(false);
                    // 飞行结束，可以再次点击按钮
                    isPlay = false;
                });
            }
        }
    }
}
