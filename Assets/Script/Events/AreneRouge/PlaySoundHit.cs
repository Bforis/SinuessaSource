using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundHit : MonoBehaviour {

	// Use this for initialization
	public AudioSource AudioSource;
	public AudioClip AreneRouge;
	void OnEnable()
	{
		AudioSource.PlayOneShot(AreneRouge);
	}
}
