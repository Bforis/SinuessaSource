using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleTurn : MonoBehaviour {

	float speed;
	public GameObject Laser;
Collider2D col;
	Animator anim;
	public AudioSource AudioSource;

	void Update () {
		if (Time.timeSinceLevelLoad <= 30 && Time.timeSinceLevelLoad >= 0)
		{
			speed = 0.5f;
		}
		else if (Time.timeSinceLevelLoad <= 60 && Time.timeSinceLevelLoad > 30)
		{
			speed = 0.8f;
		}
		else if (Time.timeSinceLevelLoad <= 90 && Time.timeSinceLevelLoad > 60)
		{
			speed = 1.2f;
		}
		else if (Time.timeSinceLevelLoad <= 120 && Time.timeSinceLevelLoad > 90)
		{
			speed = -1.5f;
		}
		else if (Time.timeSinceLevelLoad <= 150 && Time.timeSinceLevelLoad > 120)
		{
			speed = 1.8f;
		}
		else if (Time.timeSinceLevelLoad > 150)
		{
			speed = -1.8f;
		}
		transform.Rotate (Vector3.forward * speed); // Rotation
		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
         pos.x = Mathf.Clamp01(pos.x);
         pos.y = Mathf.Clamp01(pos.y);
         transform.position = Camera.main.ViewportToWorldPoint(pos); // Empêcher l'objet de out de la caméra
}

	void Fire()
	{
		anim.SetBool("Fire", true);
	}

	void ActiveCollider()
	{
		col.enabled = !col.enabled;
	}

	void Desactive()
	{
		if (col.enabled)
		{
			col.enabled = !col.enabled;
		}
	}

	void Sound()
	{
		AudioSource.Play();
	}

void Start()
{
	col = GetComponent<Collider2D>();
	anim = GetComponent<Animator>();
	speed = 0.5f;
}
}
