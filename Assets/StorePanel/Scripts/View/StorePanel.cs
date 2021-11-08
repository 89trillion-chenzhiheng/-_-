using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePanel : MonoBehaviour
{
    [Header("卡片数量必须是几个倍数")]
    [SerializeField]
    public int cardsNumWhichMultiple = 3;
    // 对StoreTitle进行引用
    [SerializeField]
    public StoreTitle storeTitle;
    // 所有货品块的统一父对象
    [SerializeField]
    public Transform cardFather;
    // 商店块展示预制体
    [SerializeField]
    public GameObject storeBlockTitlePrefab;
    // 免费金币预制体
    [SerializeField]
    public GameObject freeCoinPrefab;
    // 卡片预制体
    [SerializeField]
    public GameObject cardPrefab;
    // 锁着卡片的预制体
    [SerializeField]
    public GameObject lockPrefab; 


    public void Start()
    {
        // 获取解析后的数据
        List<BlockMessage> blockMessages = AnalysisJson.GetAnalysisJson(); 

        // 遍历数据
        foreach (var block in blockMessages)
        {
            // 根据数据类型生成不同的模块并进行不同的操作
            switch (block.type)
            {
                case RewardType.Coins:
                    // 创建免费块并添加印射
                    GameManager.Instance.AddObjHashTypeMessage(GameObject.Instantiate(freeCoinPrefab, cardFather), (int)RewardType.Coins);
                    break;
                case RewardType.Diamonds:
                    // 创建免费块并添加印射
                    GameManager.Instance.AddObjHashTypeMessage(GameObject.Instantiate(freeCoinPrefab, cardFather), (int)RewardType.Diamonds);
                    break;
                case RewardType.Cards:
                    // 创建Card块并添加印射
                    GameManager.Instance.AddObjHashTypeMessage(GameObject.Instantiate(cardPrefab, cardFather), (int)block.subType);
                    break;
                default:
                    break;
            } // end Switch(block.type)
        } // end foreach block

        // 根据数据个数动态生成锁块，使显示的卡片永远是3的倍数
        if(blockMessages.Count % cardsNumWhichMultiple != 0)
        {
            for (int i = 0; i < cardsNumWhichMultiple - blockMessages.Count % cardsNumWhichMultiple; i++) 
            {
                GameObject.Instantiate(lockPrefab, cardFather);
            } // end for i
        } // end if (blockMessages.Count % 3 != 0)
    }
}
