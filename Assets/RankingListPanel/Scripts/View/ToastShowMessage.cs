using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastShowMessage : MonoBehaviour
{
    // 显示角色名字
    [SerializeField] private Text userShowText;
    // 显示角色奖杯数量
    [SerializeField] private Text rankShowText;

    /// <summary>
    /// 打开界面
    /// </summary>
    /// <param name="user">角色名字</param>
    /// <param name="rank">角色奖杯数</param>
    public void Show(string user, string rank)
    {
        userShowText.text = user;
        rankShowText.text = rank;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
