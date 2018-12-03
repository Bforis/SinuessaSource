using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

public AudioSource AudioSource;
public AudioSource AudioMusic;


	public void PlayGame()
	{
		AudioSource.Play(0);
		AudioMusic.Stop();
		SceneManager.LoadScene("Prototype");
	}


	public void Quit()
	{
		Debug.Log("GAME LEAVE");
		Application.Quit();
	}
}
