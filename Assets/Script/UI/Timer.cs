using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

public float timer = 0;
private GUIStyle guiStyle = new GUIStyle();
public GameObject Player;
Scene currentScene;
public string GameOver, Prototype;
public bool resettimer;

	void Start () {
		
	}
	
	void Update () {
		if (currentScene.name == Prototype)
		{
           timer += Time.deltaTime;
		}
		else if (currentScene.name == GameOver)
		{
			timer = timer;
		}
		else if (resettimer == true)
		{
			timer = 0;
		}

		currentScene =SceneManager.GetActiveScene();

	}
	void OnGUI()
{
	guiStyle.fontSize = 20;
	GUI.contentColor = Color.yellow;
      int minutes = Mathf.FloorToInt(timer / 60F);
     int seconds = Mathf.FloorToInt(timer - minutes * 60);
     string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
 
     GUI.Label(new Rect(10,10,250,100), niceTime, guiStyle);
}

void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Timer");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

	public void ResetTimer()
	{
		resettimer = true;
	}

}
