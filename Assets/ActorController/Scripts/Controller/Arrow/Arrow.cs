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

    // 敌人Tag
    private string enemyTag = "Enemy";


    public void Start()
    {
        // 获取印射的伤害
        damage = GameManager.Instance.ObjHashTypeMessage(gameObject);

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
        transform.Translate(transform.up * moveSpeed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// 等待一段时间去销毁自身
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForDestroyThis()
    {
        // 等待一段时间
        yield return new WaitForSeconds(stayTime);

        // 销毁自身
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // 需要移除印射，避免数据冗余
        GameManager.Instance.RemoveObjHashTypeMessage(gameObject);
    }
}
