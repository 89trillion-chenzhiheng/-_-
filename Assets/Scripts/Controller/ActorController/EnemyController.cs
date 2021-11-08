using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class EnemyController : ActorActive
{
    // 角色当前的血量
    private int currentHP;

    void Start()
    {
        GetActorModel();
        ActorInit();
    }

    /// <summary>
    /// 受到攻击
    /// </summary>
    /// <param name="damage">伤害值</param>
    public void Hit(int damage)
    {
        // 扣血，并将血量控制在 0 - maxHP之内
        currentHP = Mathf.Clamp(currentHP - damage + actorModel.def, 0, actorModel.maxHp);
        // 刷新敌人UI显示
        actorUIMessageShow.RefreshHpShowByHpChallenge(currentHP, actorModel.maxHp);
    }

    #region ActorActive

    /// <summary>
    /// 角色初始化，如UI显示等
    /// </summary>
    public override void ActorInit()
    {
        // 获取当前生命值
        currentHP = actorModel.maxHp;
         // 刷新敌人显示
        actorUIMessageShow.RefreshHpShowByHpChallenge(currentHP, actorModel.maxHp);
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
