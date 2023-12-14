using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/SuperEnemy")]
public class SuperEnemy : Enemy {

    public Transform m_rocket;  // 子弹Prefab
    protected float m_fireTimer = 2;  // 射击计时器
    protected Transform m_player;  // 主角

    protected override void UpdateMove()
    {

        m_fireTimer -= Time.deltaTime;
        if (m_fireTimer <= 0)
        {
            m_fireTimer = 2;  // 每2秒射击一次
            if (m_player != null)
            {
                Vector3 relativePos = m_player.position - transform.position;  // 获取朝向主角的方向向量
                Instantiate(m_rocket, transform.position, Quaternion.LookRotation(relativePos)); // 创建子弹
            }
            else
            {
                GameObject obj = GameObject.FindGameObjectWithTag("Player"); // 查找主角
                if (obj != null)
                {
                    m_player = obj.transform;
                }
            }
        }
        
        // 前进
        transform.Translate(new Vector3(0, 0, -m_speed * Time.deltaTime));
    }
}
