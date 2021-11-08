using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public static class JsonRead
{
    /// <summary>
    /// 获取时间
    /// </summary>
    /// <returns></returns>
    public static string GetTimeData()
    {
        // 获取数据文件
        TextAsset txt = Resources.Load<TextAsset>("ranklist") as TextAsset;

        // 解析文件
        JSONNode jsonObject = JSON.Parse(txt.text);

        // 返回数据， 使用string是为了预防数据超出int取值范围，需要转为string，再对其进行进一步拆分操作：拆分为 天：时：分：秒
        return jsonObject["countDown"].ToString();
    }

    /// <summary>
    /// 获取所有的角色数据
    /// </summary>
    /// <returns></returns>
    public static List<ActorModel> GetActorModels()
    {
        // 创建数据存储区
        List<ActorModel> actorModels = new List<ActorModel>();

        // 获取数据文件
        TextAsset txt = Resources.Load<TextAsset>("ranklist") as TextAsset;

        // 解析文件
        JSONNode jsonObject = JSON.Parse(txt.text);

        // 解析数据至对象中
        for (int i = 0; i < jsonObject[1].Count; i++)
        {
            ActorModel actorModel;
            actorModel.uid = jsonObject[1][i]["uid"];
            actorModel.nickName = jsonObject[1][i]["nickName"];
            actorModel.avatar = int.Parse(jsonObject[1][i]["avatar"].ToString());
            actorModel.trophy = int.Parse(jsonObject[1][i]["trophy"].ToString());
            actorModels.Add(actorModel);
        }

        return actorModels;
    }
}
