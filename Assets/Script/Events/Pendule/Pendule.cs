using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendule : MonoBehaviour {

Animator anim;
public GameObject Laser;
	void Start () {
		anim = GetComponent<Animator>();
	}
	

	void Update () {
		
	}

	void Fire()
	{
		anim.SetBool("Fire", true);
	}

	void ActiveLaser()
	{
		Laser.SetActive(true);
	}
}
