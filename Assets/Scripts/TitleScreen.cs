using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[AddComponentMenu("MyGame/TitleScreen")]
public class TitleScreen : MonoBehaviour
{

    public GameObject loadScreen;//加载panel
    public Slider slider;//进度条
    public Text text;//进度显示

    // 响应游戏开始按钮事件
    public void OnButtonGameStart()
    {
        loadScreen.SetActive(true);
        StartCoroutine(LoadScene());
        // SceneManager.LoadScene("level1");
    }

    IEnumerator LoadScene(){
        // 异步加载场景
        AsyncOperation operation = SceneManager.LoadSceneAsync("level1");

        // 阻止场景自动激活 
        operation.allowSceneActivation = false;

        float startTime = Time.time;
        float endTime = startTime + 4f; // 模拟滚动的总时间（可以根据需要调整）

        while (operation.progress < 0.7f) {
            // 更新进度条和文本以显示加载进度
            float progress = Mathf.Lerp(0f, 0.7f, (Time.time - startTime) / 0.5f);
            slider.value = operation.progress;
            text.text = (operation.progress * 100).ToString("F0") + "%";
            yield return null;
        }

        // 卡在70%两三秒
        startTime = Time.time;
        while (Time.time - startTime < 2f) {
            slider.value = 0.7f;
            text.text = "70%";
            yield return null;
        }

        // 模拟70%到100%的快速滚动效果
        endTime = Time.time + 1f; // 模拟快速滚动的时间
        while (Time.time < endTime) {
            // 使用Mathf.Lerp模拟进度从70%到100%的滚动效果
            float progress = Mathf.Lerp(0.7f, 1f, 1 - (endTime - Time.time) / 0.5f);
            slider.value = progress;
            text.text = (progress * 100).ToString("F0") + "%";
            yield return null;
        }

        // 允许场景激活，加载完成
        operation.allowSceneActivation = true;

        while (!operation.isDone){
            // 显示加载完成状态
            slider.value = 1;
            text.text = "100%";
            yield return null;
        }
    }
    
}
