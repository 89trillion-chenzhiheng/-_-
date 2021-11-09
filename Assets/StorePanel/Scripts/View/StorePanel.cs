using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    // 打开界面按钮
    [SerializeField]
    public Button openPanelBtn;
    // 界面透明度，控制打开和关闭
    [SerializeField]
    public GameObject showPanel;
    // 宝箱特效
    [SerializeField]
    public ParticleSystem rewardParticleSystem;


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

    /// <summary>
    /// 打开界面按钮按下
    /// </summary>
    public void OpenPanelBtnClick()
    {
        // 对按钮显示的调整，打开界面  关闭：打开按钮
        openPanelBtn.gameObject.SetActive(false);

        // 打开该界面
        showPanel.SetActive(true);

        // 粒子特效打开
        rewardParticleSystem.Play();
    }

    /// <summary>
    /// 关闭界面按钮按下
    /// </summary>
    public void ClosePanelBtnClick()
    {
        // 对按钮显示的调整，打开界面  打开：打开按钮
        openPanelBtn.gameObject.SetActive(true);

        // 关闭该界面
        showPanel.SetActive(false);

        // 关闭粒子特效
        rewardParticleSystem.Pause();
    }
}
