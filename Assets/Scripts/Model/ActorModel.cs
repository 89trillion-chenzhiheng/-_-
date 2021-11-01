using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TableConfig;
using System;

namespace Model
{
    [Serializable]
    public class ActorModel : BaseModel
    {
        // 角色ID
        public int id;
        // 角色名字
        public string name;
        // 角色介绍
        public string note;
        // 最大血量
        public int maxHp;
        // 攻击伤害值
        public int atk;
        // 受击免疫值
        public int def;
        // 攻速
        public float shootSpeed;

        // 获取角色ID
        public override object Key()
        {
            return id;
        }
    }
}
