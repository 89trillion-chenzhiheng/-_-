using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 单例
    private static GameManager instance;

    // 创建的对象与对象类型的印射
    private Dictionary<GameObject, int> objHashTypeMessage = new Dictionary<GameObject, int>();


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
    }

    /// <summary>
    /// 添加印射
    /// </summary>
    public void AddObjHashTypeMessage(GameObject obj, int message)
    {
        objHashTypeMessage.Add(obj, message);
    }

    /// <summary>
    /// 获取Obj印射的类型
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int ObjHashTypeMessage(GameObject obj)
    {
        foreach (var item in objHashTypeMessage)
        {
            if (item.Key.Equals(obj))
            {
                return item.Value;
            }
        }
        // 如果没有，返回默认值
        return default(int);
    }
}
