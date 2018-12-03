using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFalse : MonoBehaviour {

	public GameObject Laser;
	void OnEnable()
	{
		Laser.SetActive(false);
	}
}
