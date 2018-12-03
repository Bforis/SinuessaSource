using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCimetierre : MonoBehaviour {

Collider2D col;
public AudioSource AudioSource;
public AudioClip Cimetierre;
	void Start () {
		col = GetComponent<Collider2D>();
	}

	void Update () {
		
	}

	void ActiveCollider()
	{
		col.enabled = !col.enabled;
	}

	void PlaySound()
	{
		AudioSource.PlayOneShot(Cimetierre);
	}
}
