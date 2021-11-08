using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class ActorActive : MonoBehaviour
{
    // 角色动画播放器
    public Animator playerAnim;
    // UI显示面板
    public ActorUIMessageShow actorUIMessageShow;
    // 角色数据对象
    [HideInInspector]
    public ActorModel actorModel;

    /// <summary>
    /// 角色初始化，如UI显示等
    /// </summary>
    public virtual void ActorInit() { }
    /// <summary>
    /// 射击操作
    /// </summary>
    public virtual void Shoot() { }
    /// <summary>
    /// 获取数据
    /// </summary>
    public virtual void GetActorModel() { }
}
