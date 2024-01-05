using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScreen : MonoBehaviour {

	//退出至菜单
	public void OnButtonGameToMenu(){
        SceneManager.LoadScene("start");
		Time.timeScale = 1;
	}
 
	//NoBtn
	public void OnButtonGameNo(GameObject exitPanel){
		GameObject.FindWithTag("Player").GetComponent<Player>().setExitNum(false);
        Time.timeScale = 1;
        exitPanel.SetActive(false);
    }
}
