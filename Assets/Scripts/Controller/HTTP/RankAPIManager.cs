using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankAPIManager
{
    /// <summary>
    /// 创建新的HTTP请求，请求排行榜
    /// </summary>
    /// <param name="obj">请求的唯一标识</param>
    /// <param name="successCallBack">请求成功的回调函数</param>
    public void RequestNewRankList(GameObject obj, Action<string> successCallBack)
    {
        // 创建新的请求
        GetHTTPData rankListAPI = new GetHTTPData(obj);
        // 注册请求成功的事件
        rankListAPI.OnSuccess += data => { successCallBack(data); };
        // 发送请求
        rankListAPI.Requst();
    }
}
