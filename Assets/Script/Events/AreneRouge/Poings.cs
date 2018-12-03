using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poings : MonoBehaviour {

	public GameObject Zone1;
	public GameObject Hit1;
	public GameObject Poing;
public GameObject Arene;
	void OnEnable () {
		if (Poing.activeSelf)
		{
		StartCoroutine(ZoneAndHit());
		}
	}

	IEnumerator ZoneAndHit()
	{
		{
		Zone1.SetActive(true);
		yield return new WaitForSeconds(2);
		Hit1.SetActive(true);
		yield return new WaitForSeconds(1f);
		Hit1.SetActive(false);
		Zone1.SetActive(false);
		}
	}

}
