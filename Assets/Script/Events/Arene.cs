using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arene : MonoBehaviour {

	public GameObject arene;
	public GameObject Poing;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!Poing.activeSelf && !arene.activeSelf)
		{
			arene.SetActive(true);
		}
	}
}
