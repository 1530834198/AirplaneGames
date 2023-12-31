using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/BuffSpawn")]
public class BuffSpawn : MonoBehaviour {

	public Transform m_rocketPrefb; // buff道具的Prefab
    public Transform m_bloodPrefab; // 回血道具的Prefab

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnBuff());
	}

    IEnumerator SpawnBuff()//使用协程创建血包
    {
        while (true)
        {
			// 随机等待时间，范围为10到30秒
    		float waitTime = Random.Range(10f, 30f);
            // 生成一个道具后结束协程
            yield return new WaitForSeconds(waitTime);
            // 随机选择要实例化的预制体
            Transform prefabToInstantiate = Random.Range(0, 2) == 0 ? m_rocketPrefb : m_bloodPrefab;

            // 实例化预制体
            Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon (transform.position, "item.png", true);
    }
}
