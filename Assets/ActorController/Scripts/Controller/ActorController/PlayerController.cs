using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class PlayerController : ActorActive
{
    // 箭的预制体
    [SerializeField] private GameObject arrowPrefab;
    // 箭的父对象，用于收纳和初始化箭的位置
    [SerializeField] private Transform arrowFriend;

    // 什么时间可以射击
    private float canShootTime = -999f;

    // Start is called before the first frame update
    void Start()
    {
        GetActorModel();
        ActorInit();
    }

    void Update()
    {
        // 从任意状态进入静止
        if(Input.GetKeyDown(KeyCode.I))
        {
            playerAnim.SetTrigger("Idle");
            playerAnim.SetBool("Run", false);
        }
        // 跑步
        else if(Input.GetKey(KeyCode.R))
        {
            playerAnim.SetBool("Run", true);
        }
        // 跑步结束
        else if(Input.GetKeyUp(KeyCode.R))
        {
            playerAnim.SetBool("Run", false);
        }
        // 射击
        if (Input.GetKeyDown(KeyCode.A) && canShootTime <= Time.time)
        {
            canShootTime = Time.time + actorModel.shootSpeed;
            Shoot();
        }

    }

    /// <summary>
    /// 攻击动画回调函数，此时去创建箭
    /// </summary>
    public void AnimationCallBack()
    {
        // 创建箭头
        GameManager.Instance.AddObjHashTypeMessage(GameObject.Instantiate(arrowPrefab, arrowFriend), actorModel.atk);
    }

    #region ActorActive

    /// <summary>
    /// 角色初始化，如UI显示等
    /// </summary>
    public override void ActorInit()
    {
        // 刷新UI显示
        actorUIMessageShow.RefreshHpShowByHpChallenge(actorModel.maxHp, actorModel.maxHp);
    }

    /// <summary>
    /// 射击
    /// </summary>
    public override void Shoot()
    {
        // 播放攻击动画
        playerAnim.SetTrigger("Attack");
    }

    /// <summary>
    /// 获取数据
    /// </summary>
    public override void GetActorModel()
    {
        // 获取数据
        List<ActorModel> actorModels = GameModelManager.instance.GetActorModel();
        // 要保证文件中有数据
        if (actorModels.Count == 0)
        {
            Debug.LogError("没有任何数据可以读取");
        }
        // 返回数据
        actorModel = actorModels[0];
    }

    #endregion
}
