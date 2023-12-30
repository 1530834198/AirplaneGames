using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/Blood")]
public class Blood : MonoBehaviour {

	public float b_speed = 1;   // 速度
    public int b_life = 1;//血量

    internal Renderer m_renderer;  // 模型渲染组件
    internal bool m_isActiv = false;  // 是否激活

	void Start()
	{
		m_renderer = GetComponent<Renderer>(); // 获得模型渲染组件
		if (m_renderer == null)
		{
			var rs = GetComponentsInChildren<Renderer>();
			foreach (var render in rs)
			{
				if (!render.name.StartsWith("col"))
				{
					m_renderer = render;
					break;
				}
			}
		}

		// 设置每个Blood对象的初始偏移
		transform.Translate(new Vector3(Random.Range(-5f, 5f), 0, 0));
	}


    void OnBecameVisible()  // 当模型进入屏幕
    {
        m_isActiv = true;
    }
	
	// Update is called once per frame
	void Update () {

        UpdateMove();

        if (m_isActiv && !this.m_renderer.isVisible )  // 如果移动到屏幕外
        {
            Destroy(this.gameObject); // 自我销毁
        }
	}

    protected virtual void UpdateMove()
    {
        // 左右移动
		float rx = Mathf.Sin(Time.time * b_speed) * Time.deltaTime;

		// 前进
		transform.Translate(new Vector3(rx, 0, -b_speed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")  // 如果撞到主角
        {
            Destroy(this.gameObject); // 自我销毁
        }
        
    }
}
