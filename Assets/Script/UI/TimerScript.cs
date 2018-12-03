using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

public float timer = 0;
private GUIStyle guiStyle = new GUIStyle();
private GUIStyle GameOverStyle = new GUIStyle();
public GameObject Player;
Scene currentScene;
public string GameOver, Prototype;
public bool resettimer;

	void Start () {
		// guiStyle.fontSize = (int)(50.0f * (float)(Screen.width)/1920.0f);
		GameOverStyle.fontSize = (int)(100.0f * (float)(Screen.width)/1920.0f);
		// guiStyle.normal.textColor = new Color(1, 0.92f, 0.016f, 1);
		GameOverStyle.normal.textColor = new Color(0.6f, 1, 1, 1);
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
	
	// GUI.contentColor = Color.red;
      int minutes = Mathf.FloorToInt(timer / 60F);
     int seconds = Mathf.FloorToInt(timer - minutes * 60);
     string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
/*  if (currentScene.name == Prototype)
	{
     GUI.Label(new Rect(10,10,250,100), niceTime, guiStyle); // Chrono jeu
	}*/
	if (currentScene.name == GameOver)
	{
		GUI.Label(new Rect(Screen.width/2.14f, Screen.height/3.2f, 250, 110), niceTime, GameOverStyle); // Chrono gameover
	}
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
