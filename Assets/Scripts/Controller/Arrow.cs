using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // 箭飞行速度
    public float moveSpeed;
    // 箭飞行时间
    public float stayTime;
    // 箭的伤害
    [HideInInspector]
    public int damage;


    public void Start()
    {
        StartCoroutine(WaitForDestroyThis());
    }

    public void OnTriggerEnter(Collider other)
    {
        // 如果碰撞的是敌人
        if (other.gameObject.tag.Equals("Enemy")) 
        {
            // 敌人扣血
            other.gameObject.GetComponent<EnemyController>().Hit(damage);
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
}
