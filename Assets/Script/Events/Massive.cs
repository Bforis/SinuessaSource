using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Massive : MonoBehaviour {

	public GameObject Player;
	public GameObject SpawnMassive;
	public GameObject Massiv;
	float maxSize;
    float growFactor;
     public float waitTime;
	 Vector3 originalPos;
	 Vector3 ResetScale;

	void Start () {
       maxSize = 4f;
       growFactor = 0.5f;
	}

	void OnEnable()
	{
StartCoroutine(Scale());
	}	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards(transform.position,Player.transform.position, 2 *Time.deltaTime);
	}


	     IEnumerator Scale()
     {
// Difficulté croissante
        if (Time.timeSinceLevelLoad <= 30 && Time.timeSinceLevelLoad >= 0)
		{
			maxSize = 5f;
growFactor = 0.5f;
		}
		else if (Time.timeSinceLevelLoad <= 60 && Time.timeSinceLevelLoad > 30)
		{
			maxSize = 6f;
growFactor = 1;
		}
		else if (Time.timeSinceLevelLoad <= 90 && Time.timeSinceLevelLoad > 60)
		{
			maxSize = 6.5f;
growFactor = 1.5f;
		}
		else if (Time.timeSinceLevelLoad <= 120 && Time.timeSinceLevelLoad > 90)
		{
			maxSize = 7f;
growFactor = 2;
		}
		else if (Time.timeSinceLevelLoad <= 150 && Time.timeSinceLevelLoad > 120)
		{
			maxSize = 7.5f;
growFactor = 2.5f;
		}
		else if (Time.timeSinceLevelLoad <= 180 && Time.timeSinceLevelLoad >= 150)
		{
			maxSize = 8f;
growFactor = 3f;
		}
		else if (Time.timeSinceLevelLoad > 180)
		{
			maxSize = 8.5f;
            growFactor = 6f;
		}
         float timer = 0;
 
         if (SpawnMassive.activeSelf)
         {
             while(maxSize > transform.localScale.x)
             {
                 timer += Time.deltaTime;
                 transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                 yield return null;
             }
             // reset
             yield return new WaitForSeconds(waitTime);
 
             timer = 0;
             while(1 < transform.localScale.x)
             {
                 timer += Time.deltaTime;
                 transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                 yield return null;
             }
 
             timer = 0;
             yield return new WaitForSeconds(waitTime);
         }
}
}
