using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMesssageUIShow : MonoBehaviour
{
    // 玩家的ID
    [SerializeField] private string playerID;
    // 奖杯数量显示
    [SerializeField] private Text trophyNumText;
    // 玩家排名显示
    [SerializeField] private Text rankingNumText;
    // 玩家ID显示
    [SerializeField] private Text UIdText;
    // 角色名字显示
    [SerializeField] private Text nickNameText;

    public void Awake()
    {
        // 遍历找到玩家的数据
        for (int index = 0; index < GameMessageModel.ActorModels.Count; index++) 
        {
            // 获取引用
            ActorModel actorModel = GameMessageModel.ActorModels[index];
            // 如果ID一致，则找到角色
            if(actorModel.uid.Equals(playerID))
            {
                // 将角色的信息显示到UI中
                trophyNumText.text = actorModel.trophy.ToString();
                rankingNumText.text = (index + 1).ToString();
                UIdText.text = actorModel.uid;
                nickNameText.text = actorModel.nickName;
                break;
            }
        }
    }
}
