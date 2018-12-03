using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGM : MonoBehaviour {

	public GameObject ResetTimer;
	public AudioSource AudioButton;
	public AudioSource AudioMusic;


	void Start () {

	}

	void Update () {
	}

	public void DestroyTimer()
	{
		Destroy(GameObject.Find("Timer"));
	}

	public void TryAgain()
	{
		AudioButton.Play(0);
		AudioMusic.Stop();
		SceneManager.LoadScene("Prototype");
	}


	public void Quit()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}
}
