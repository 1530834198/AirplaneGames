using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour {

	public VideoPlayer videoPlayer;
	public GameObject[] objectsToPause; // 其他需要暂停的对象数组
	public bool isInvincible = false;//是否复活
	void Start () {

        // 检查 VideoPlayer 是否存在
        if (videoPlayer != null)
        {
            // 绑定播放完成事件
            videoPlayer.loopPointReached += OnVideoFinished;

			// 播放视频
            PlayVideo();
        }
        else
        {
            Debug.LogError("VideoPlayer component not found!");
        }
	}
	

    void OnVideoFinished(VideoPlayer vp)
    {
		// 恢复游戏
        ResumeGame();
		//传参数
		GameObject.FindWithTag("Player").GetComponent<Player>().isInvincible = true;
		// 销毁
        Destroy(gameObject);
    }

	void PlayVideo()
    {
        // 暂停游戏中的其他对象
        PauseGame();

        // 开始播放视频
        videoPlayer.Play();
    }

    void PauseGame()
    {
        // 暂停游戏中的其他对象
        Time.timeScale = 0;

        // 在这里可以添加其他暂停游戏的逻辑
        if (objectsToPause != null)
        {
            foreach (var obj in objectsToPause)
            {
                obj.SetActive(false);
            }
        }
    }

    void ResumeGame()
    {
        // 恢复游戏
        Time.timeScale = 1;

        // 在这里可以添加其他恢复游戏的逻辑
        if (objectsToPause != null)
        {
            foreach (var obj in objectsToPause)
            {
                obj.SetActive(true);
            }
        }
    }

}
