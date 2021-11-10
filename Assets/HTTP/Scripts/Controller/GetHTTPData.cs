using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHTTPData : BaseAPI
{
    public GetHTTPData(GameObject go) : base(go)
    {
        ForceRequest = false;
    }

    /// <summary>
    /// 发起HTTP请求
    /// </summary>
    public void Requst(string path, int type, int page, int season, string token)
    {
        var httpClient = CreateHTTPClickBuild(path, type, page, season, token);
        SendRequest(httpClient);
    }

    /// <summary>
    /// 创建请求对象
    /// </summary>
    /// <returns></returns>
    private HttpClientBuilder CreateHTTPClickBuild(string path, int type, int page, int season, string token)
    {
        // 构建请求命令
        HttpClientBuilder httpClientBuilder = new HttpClientBuilder(path)
            .Param("type", type)
            .Param("page", page)
            .Param("season", season)
            .Param("token", token)
            .Method(HttpMethod.Get);

        // 返回请求对象
        return httpClientBuilder;
    }
}
