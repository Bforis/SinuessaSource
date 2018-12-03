using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour {

public List<GameObject> AllEvents; // Element 0 et 1 Pairs.
public int lastValue;
public GameObject Laser;
public GameObject Pendule;

	void Start () {
StartCoroutine(Actif());
}

void Update()
{
	if (!Pendule.activeSelf)
	{
		Laser.SetActive(false);
	}
}
	
	IEnumerator Actif()
  {
	  yield return new WaitForSeconds(5f);
	  GameObject randomEvents = AllEvents[UniqueRandom(0, AllEvents.Count)];
	 //  int i = 0;
	  while (true)
	  {
	  randomEvents.SetActive(true);
	  if (AllEvents[1].activeSelf)
	  {
		  yield return new WaitForSeconds(3.8f);
		  randomEvents.SetActive(false);
	  }
	  else if ( AllEvents[3].activeSelf)
	  {
		  yield return new WaitForSeconds(5);
		  randomEvents.SetActive(false);
	  }
	  /*  else if ( AllEvents[5].activeSelf)
	  {
		  yield return new WaitForSeconds(8);
		  randomEvents.SetActive(false);
	  }
	  */
	  else if ( Time.time < 30)
	  {
	yield return new WaitForSeconds(10);
	  randomEvents.SetActive(false);
	  }
	  else if (Time.time > 30)
	  {
		  yield return new WaitForSeconds(8);
	  randomEvents.SetActive(false);
	  }
	  else if (Time.time > 60)
	  {
		  yield return new WaitForSeconds(6);
	  randomEvents.SetActive(false);
	  }
	  else if (Time.time > 90)
	  {
		  yield return new WaitForSeconds(5);
		  randomEvents.SetActive(false);
	  }
	  yield return new WaitForSeconds(0.1f);
	  // randomEvents = AllEvents[Random.Range(0, AllEvents.Count)];
	  randomEvents = AllEvents[UniqueRandom(0, AllEvents.Count)]; // Lié UniqueRandom
	  randomEvents.SetActive(true);
	  }
  }

public int UniqueRandom(int min, int max) // Empêche la répétition des events
{
    int val = Random.Range(min, max);
    while(lastValue == val)
    {
        val = Random.Range(min, max);
    }
    lastValue = val;
    return val;
}

}

