using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // 箭飞行速度
    [SerializeField] private float moveSpeed;
    // 箭飞行时间
    [SerializeField] private float stayTime;
    // 箭的伤害
    [HideInInspector]
    public int damage;

    // 箭的预制体
    private GameObject arrowPrefab;
    // 敌人Tag
    private string enemyTag = "Enemy";


    public void OnEnable()
    {
        // 获取印射的伤害
        KeyValuePair<int, GameObject> valuePair = GameManager.Instance.ObjHashTypeMessage(gameObject);
        damage = valuePair.Key;
        arrowPrefab = valuePair.Value;

        StartCoroutine(WaitForDestroyThis());
    }

    public void OnTriggerEnter(Collider other)
    {
        // 如果碰撞的是敌人
        if (other.gameObject.tag.Equals(enemyTag)) 
        {
            // 敌人扣血
            GameManager.Instance.EnemyHit(damage);
        }
    }

    public void FixedUpdate()
    {
        // 箭移动
        transform.Translate(-transform.right * moveSpeed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// 等待一段时间去销毁自身
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForDestroyThis()
    {
        // 等待一段时间
        yield return new WaitForSeconds(stayTime);

        // 飞行结束
        FlyEnd();
    }

    /// <summary>
    /// 飞行结束进行的操作
    /// </summary>
    private void FlyEnd()
    {
        gameObject.SetActive(false);
        // 需要移除印射，避免数据冗余
        GameManager.Instance.RemoveObjHashTypeMessage(gameObject);
        // 物体返回对象池
        GameManager.Instance.poolManager.Recycle(arrowPrefab, gameObject);
    }
}
