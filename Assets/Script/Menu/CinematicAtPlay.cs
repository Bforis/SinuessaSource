using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicAtPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(JumpLevel());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("Prototype");
		}
	}

	IEnumerator JumpLevel()
	{
		yield return new WaitForSeconds(17);
		SceneManager.LoadScene("Prototype");
	}
}
