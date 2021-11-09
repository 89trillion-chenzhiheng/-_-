using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    // 对象池
    Dictionary<GameObject, Stack<GameObject>> poolDic;
    // 池子存放位置
    Transform poolContainer;


    /// <summary>
    /// 进行默认初始化
    /// </summary>
    public PoolManager()
    {
        // 给池子的数据进行初始化
        poolDic = new Dictionary<GameObject, Stack<GameObject>>();
        // 创建池子
        poolContainer = new GameObject("PoolContainer").transform;
        // 池子的的物理位置
        poolContainer.parent = GameManager.Instance.transform;
        // 池子需要默认隐藏
        poolContainer.gameObject.SetActive(false);
    }

    /// <summary>
    /// 从池子中获取一个物体
    /// </summary>
    /// <param name="prefab">物体的Prefab</param>
    /// <returns></returns>
    public GameObject Get(GameObject prefab)
    {
        // prefab为空
        if (prefab == null)
        {
            Debug.LogError("空prefab");
        }
        // 池子中没有该类型的物体
        if (!poolDic.ContainsKey(prefab))
        {
            //没有就创建一个
            poolDic.Add(prefab, new Stack<GameObject>());
        }
        // 获取该类型的池子
        Stack<GameObject> currentStack = poolDic[prefab];
        // 如果池子中没有物体则去创建一个并返回
        if (currentStack.Count <= 0)
        {
            GameObject newGo = GameObject.Instantiate(prefab);
            newGo.gameObject.name = prefab.name;
            return newGo;
        }
        // 池子中有则取出一个
        else
        {
            // 取出物体
            GameObject go = currentStack.Pop();
            // 物体为NULL？存入一个空物体 || 对象池中的物体被销毁
            if (go == null)
            {
                // 该空物体已经取出，递归重新从池子中获取
                return Get(prefab);
            }
            // 从池子取出后的初始化
            go.transform.parent = null;
            // 返回取出的物体
            return go;
        }
    }

    /// <summary>
    /// 放回对象池
    /// </summary>
    /// <param name="prefab">物体的prefab</param>
    /// <param name="go">物体</param>
    public void Recycle(GameObject prefab, GameObject go)
    {
        // 为什么存入一个空的物体？存入空物体直接退出
        if (go == null)
        {
            return;
        }
        // 存入物体的初始化：装入物理池子
        if (go.transform.parent == poolContainer)
        {
            return;
        }
        // 装入数据池子：获取引用
        Stack<GameObject> currentStack;
        // 如果没有该物体的池子就去添加一个
        if (!poolDic.TryGetValue(prefab, out currentStack) || prefab == null)
        {
            currentStack = new Stack<GameObject>();
            poolDic.Add(prefab, currentStack);
        }
        // 像池子中加入物体
        currentStack.Push(go);
        // 并设置一下物理位置
        go.transform.parent = poolContainer;
    }
}