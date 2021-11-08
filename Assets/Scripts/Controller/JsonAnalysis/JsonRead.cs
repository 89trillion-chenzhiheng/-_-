using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public static class JsonRead
{
    /// <summary>
    /// 获取所有的角色数据
    /// </summary>
    /// <returns></returns>
    public static List<ActorModel> GetActorModels(string data)
    {
        // 创建数据存储区
        List<ActorModel> actorModels = new List<ActorModel>();

        // 解析文件
        JSONNode jsonObject = JSON.Parse(data);

        // 解析数据至对象中
        for (int i = 0; i < jsonObject[2][0].Count; i++)
        {
            ActorModel actorModel;
            actorModel.uid = jsonObject[2][0][i]["uid"];
            actorModel.nickName = jsonObject[2][0][i]["nickName"];
            actorModel.avatar = int.Parse(jsonObject[2][0][i]["avatar"].ToString());
            actorModel.trophy = int.Parse(jsonObject[2][0][i]["trophy"].ToString());
            actorModels.Add(actorModel);
        }

        return actorModels;
    }
}
