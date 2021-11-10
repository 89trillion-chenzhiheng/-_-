using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public class AnalysisJson
{
    public static List<BlockMessage> GetAnalysisJson()
    {
        // 创建数据列表
        List<BlockMessage> blockMessages = new List<BlockMessage>();

        // 获取数据文件
        TextAsset txt = Resources.Load<TextAsset>("JsonData") as TextAsset;

        // 解析文件
        JSONNode jsonObject = null;
        try
        {
            jsonObject = JSON.Parse(txt.text);
        }
        catch (System.Exception ex)
        {
            // 异常处理，如果出现异常，返回null表示数据错误，没有获取到数据
            Debug.Log(ex);
            return null;
        }

        // 将数据存入列表
        for (int i = 0; i < jsonObject[0].Count; i++)
        {
            // 解析数据并将数据存入数据类中
            BlockMessage fieldRead = new BlockMessage();
            fieldRead.productID = jsonObject[0][i]["productId"];
            fieldRead.type = (RewardType)(int)jsonObject[0][i]["type"];
            fieldRead.subType = (RewardType)(int)jsonObject[0][i]["subType"];
            fieldRead.num = jsonObject[0][i]["num"];
            fieldRead.costGold = jsonObject[0][i]["costGold"];
            fieldRead.costGem = jsonObject[0][i]["costDiamond"];
            fieldRead.isPurchased = jsonObject[0][i]["isPurchased"];

            // 将数据类存入数据列表
            blockMessages.Add(fieldRead);
        }

        //将获取的数据列表返回
        return blockMessages;
    }
}
