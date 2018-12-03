using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	public AudioSource AudioSource;
	public AudioClip AreneRouge;
	void SoundPlay()
	{
		AudioSource.PlayOneShot(AreneRouge);
	}
}
