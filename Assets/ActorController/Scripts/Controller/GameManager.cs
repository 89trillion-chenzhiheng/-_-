using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 对象池
    [HideInInspector]
    public PoolManager poolManager;
    // 敌人的控制器，用于扣血
    [SerializeField] private EnemyController enemyController;

    // 单例
    private static GameManager instance;

    // 创建的对象与对象类型的印射
    private Dictionary<GameObject, KeyValuePair<int, GameObject>> objHashTypeMessage = new Dictionary<GameObject, KeyValuePair<int, GameObject>>();


    // 获取单例
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void Awake()
    {
        instance = this;

        poolManager = new PoolManager();
    }

    /// <summary>
    /// 添加印射
    /// </summary>
    public void AddObjHashTypeMessage(GameObject obj, KeyValuePair<int, GameObject> message)
    {
        objHashTypeMessage.Add(obj, message);
    }

    /// <summary>
    /// 获取Obj印射的类型
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public KeyValuePair<int, GameObject> ObjHashTypeMessage(GameObject obj)
    {
        foreach (var item in objHashTypeMessage)
        {
            if (item.Key.Equals(obj))
            {
                return item.Value;
            }
        }
        // 如果没有，返回默认值
        return default(KeyValuePair<int, GameObject>);
    }

    /// <summary>
    /// 移除印射
    /// </summary>
    public void RemoveObjHashTypeMessage(GameObject obj)
    {
        // 循环Key，如果是要删除的印射，则进行删除并退出循环
        foreach (var item in objHashTypeMessage) 
        {
            if (item.Key.Equals(obj)) 
            {
                objHashTypeMessage.Remove(item.Key);
                break;
            }
        }
    }

    /// <summary>
    /// 敌人受到攻击后去扣血
    /// </summary>
    /// <param name="damage">伤害值</param>
    public void EnemyHit(int damage)
    {
        enemyController.Hit(damage);
    }
}
