using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/EnemySpawn")]
public class EnemySpawn : MonoBehaviour
{
    public Transform m_enemyPrefb; // 敌人的Prefab

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemy());  // 启动协程
	}

    IEnumerator SpawnEnemy() // 使用协程创建敌人
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 15));  // 每N秒生成一个敌人
            Instantiate(m_enemyPrefb, transform.position, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon (transform.position, "item.png", true);
    }

}
