using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperRocket : MonoBehaviour {

	public float m_speed = 15;  // 子弹飞行速度
    public float m_power = 5.0f;  // 威力

	// Use this for initialization
	void OnBecameInvisible() {
        if (this.enabled)  // 防止重复删除
            Destroy(this.gameObject);  // 当离开屏幕后销毁
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate( new Vector3( 0, 0, m_speed * Time.deltaTime ) );  // 向前移动
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag!="Enemy")
            return;

        Destroy(this.gameObject);
    }
}
