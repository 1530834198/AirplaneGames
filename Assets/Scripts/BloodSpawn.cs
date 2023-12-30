using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/BloodSpawn")]
public class BloodSpawn : MonoBehaviour {

	public Transform m_healthItemPrefab; // 回血道具的Prefab

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnBlood());
	}

    IEnumerator SpawnBlood()//使用协程创建血包
    {
        while (true)
        {
			// 随机等待时间，范围为10到60秒
    		float waitTime = Random.Range(10f, 60f);
            // 生成一个道具后结束协程
            yield return new WaitForSeconds(waitTime);  // 等待5秒
            Instantiate(m_healthItemPrefab, transform.position, Quaternion.identity);
            // 可以选择销毁 Blood 对象，或者让其禁用（gameObject.SetActive(false);）
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon (transform.position, "item.png", true);
    }
}
