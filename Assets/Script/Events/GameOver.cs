using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {


	// Use this for initialization
	void Start () {
		StartCoroutine(GameOverMenu());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("GameOver");
		}
	}

	IEnumerator GameOverMenu()
	{
		yield return new WaitForSeconds(10);
		SceneManager.LoadScene("GameOver");
	}
}
