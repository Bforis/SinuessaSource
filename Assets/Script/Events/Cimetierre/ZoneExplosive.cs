using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneExplosive : MonoBehaviour {

public GameObject Mainzone;
	public GameObject Zone;
	public GameObject Hit;
	public GameObject ZONE;
	float waiting;
	
	void OnEnable () {
		if (ZONE.activeSelf)
		{
StartCoroutine(ZoneSpawn());
		}
	}
	
	void Start()
	{
		waiting = 0.6f;
	}
	
	// Update is called once per frame
	void Update () {
if (gameObject.name == "CloneZone") // Destroying Zone
{
	Destroy(gameObject, 3);
}
}

IEnumerator ZoneSpawn()
	{
		if (Time.timeSinceLevelLoad <= 30 && Time.timeSinceLevelLoad >= 0)
		{
			waiting = 0.6f;
		}
		else if (Time.timeSinceLevelLoad <= 60 && Time.timeSinceLevelLoad > 30)
		{
			waiting = 0.4f;
		}
		else if (Time.timeSinceLevelLoad <= 90 && Time.timeSinceLevelLoad > 60)
		{
			waiting = 0.3f;
		}
		else if (Time.timeSinceLevelLoad <= 120 && Time.timeSinceLevelLoad > 90)
		{
			waiting = 0.2f;
		}
		else if (Time.timeSinceLevelLoad <= 150 && Time.timeSinceLevelLoad > 120)
		{
			waiting = 0.15f;
		}
		else if (Time.timeSinceLevelLoad <= 180 && Time.timeSinceLevelLoad >= 150)
		{
			waiting = 0.10f;
		}
		else if (Time.timeSinceLevelLoad > 180)
		{
			waiting = 0.05f;
		}
		//  Physic2D.Overlapcircle
	List <GameObject> CloneList = new List<GameObject>();
	yield return new WaitForSeconds(waiting);
	float range = 2.5f;
	Vector3 randomPos = Random.insideUnitSphere * range;
	Vector3 screenPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.11f, 0.91f), Random.Range(0.5f, 0.85f), Camera.main.farClipPlane/2));
     GameObject CloneMainZone = Instantiate(Mainzone, screenPosition + randomPos, transform.rotation);
	 CloneMainZone.name = "CloneZone";
	 CloneList.Add(CloneMainZone);
	    Zone.SetActive(true);
		 yield return new WaitForSeconds(0.7f);
		 Hit.SetActive(true);
		 yield return new WaitForSeconds(0.9f);
		 Zone.SetActive(false);
		 Hit.SetActive(false);
	}

}

	
    



