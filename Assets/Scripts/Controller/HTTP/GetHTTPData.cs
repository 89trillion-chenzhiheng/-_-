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
    public void Requst()
    {
        var httpClient = CreateHTTPClickBuild();
        SendRequest(httpClient);
    }

    /// <summary>
    /// 创建请求对象
    /// </summary>
    /// <returns></returns>
    private HttpClientBuilder CreateHTTPClickBuild()
    {
        // 构建请求命令
        HttpClientBuilder httpClientBuilder = new HttpClientBuilder("http://api-s2.artofwarconquest.com/admin/rankList")
            .Param("type", 1)
            .Param("page", 1)
            .Param("season", 18)
            .Param("token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiI0MzY4NjY1MjcifQ.drFj2OtLEjgE452sgtHPG73xU-yQ-OXvbz4Utxl2M1k")
            .Method(HttpMethod.Get);

        // 返回请求对象
        return httpClientBuilder;
    }
}
