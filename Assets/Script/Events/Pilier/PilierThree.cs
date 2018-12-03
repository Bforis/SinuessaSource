using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilierThree : MonoBehaviour {
public float moveSpeed ;
    public Vector3 dir;
    public float turnSpeed;
    float targetAngle;
    Vector3 currentPos;
    bool play=true;
    Vector3 direction;
	Vector3 originalPos;
	public GameObject spawner;
    void Start()
    {
		originalPos = new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z);
        dir = Vector3.up;
        InvokeRepeating ("Start1", 0f, 5f);
    }
    void Start1(){
        play = true;
        direction = new Vector3(Random.Range(-3.0f,3.0f),Random.Range(-4.0f,4.0f),0); 
    }
    void Update()
    {
         currentPos = transform.position;
        if(play)
        { //calculating direction
        dir = direction - currentPos;  
        dir.z = 0;
        dir.Normalize ();
        play = false;
        }    
        Vector3 target = dir * moveSpeed + currentPos;  
        transform.position = Vector3.Lerp (currentPos, target, Time.deltaTime);
         targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; 
        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, targetAngle), turnSpeed * Time.deltaTime); 
		if (Time.timeSinceLevelLoad <= 30 && Time.timeSinceLevelLoad >= 0)
		{
			moveSpeed = 5f;
		}
		else if (Time.timeSinceLevelLoad <= 60 && Time.timeSinceLevelLoad > 30)
		{
			moveSpeed = 6f;
		}
		else if (Time.timeSinceLevelLoad <= 90 && Time.timeSinceLevelLoad > 60)
		{
			moveSpeed = 6.5f;
			}
		else if (Time.timeSinceLevelLoad <= 120 && Time.timeSinceLevelLoad > 90)
		{
			moveSpeed = 7f;
		}
		else if (Time.timeSinceLevelLoad <= 150 && Time.timeSinceLevelLoad > 120)
		{
			moveSpeed = 7.5f;
		}
		else if (Time.timeSinceLevelLoad <= 180 && Time.timeSinceLevelLoad >= 150)
		{
			moveSpeed = 8f;

		}
		else if (Time.timeSinceLevelLoad > 180)
		{
			moveSpeed = 8.5f;
		}
    }
    void OnCollisionEnter2D()
    {
        
            CancelInvoke ();
            direction = new Vector3 (Random.Range (-3.0f, 3.0f), Random.Range (-4.0f, 4.0f), 0); 
            play = true;
    
    }
    void OnCollisionExit2D()
    {
        InvokeRepeating ("Start1", 2f, 5f);
    }

	void OnEnable()
	{
		gameObject.transform.position = originalPos;
	}
}