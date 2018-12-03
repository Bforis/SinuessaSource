using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBalls : MonoBehaviour {

public GameObject balls;
public GameObject BALLS;
public GameObject wallRight;
public GameObject wallLeft;
float waiting;
Animator anim;
public AudioSource AudioBalls;

float speed;
	void OnEnable() {
		if (BALLS.activeSelf)
		{
StartCoroutine(SpawnBallsLeft());
		}
	}

	void Start()
	{
		waiting = 1.5f;
		anim = GetComponent<Animator>();
		anim.SetBool("Move", false);
	}

	void Update()
	{
		if (!BALLS.activeSelf)
		{
			if (gameObject.name == "Balls")
			{
				Destroy(gameObject, 5);
			}
		}

	}

// COLLISION

private void OnCollisionEnter2D(Collision2D collision)
{
	if (collision.gameObject.tag == "Player")
	{
		AudioBalls.Play();
		anim.SetBool("DIE", true);
		StartCoroutine(AnimationWait());
	}
	if (collision.gameObject == wallLeft)
	{
		Destroy(balls);
	}
	if(collision.gameObject == wallRight)
	{
		Destroy(balls);
	}
		if (collision.gameObject.tag =="Massive")
	{
		AudioBalls.Play();
		anim.SetBool("DIE", true);
		StartCoroutine(AnimationWait());
	}
}
IEnumerator SpawnBallsLeft()
{
	// Difficulté croissante
		if (Time.timeSinceLevelLoad <= 30 && Time.timeSinceLevelLoad >= 0)
		{
			waiting = 1.5f;
			speed = Random.Range(8, 4);
		}
		else if (Time.timeSinceLevelLoad <= 60 && Time.timeSinceLevelLoad > 30)
		{
			waiting = 1.2f;
			speed = Random.Range(8, 5);
		}
		else if (Time.timeSinceLevelLoad <= 90 && Time.timeSinceLevelLoad > 60)
		{
			waiting = 0.9f;
			speed = Random.Range(9, 5);
		}
		else if (Time.timeSinceLevelLoad <= 120 && Time.timeSinceLevelLoad > 90)
		{
			waiting = 0.6f;
			speed = Random.Range(9, 6);
		}
		else if (Time.timeSinceLevelLoad <= 150 && Time.timeSinceLevelLoad > 120)
		{
			waiting = 0.3f;
			speed = Random.Range(10, 6);
		}
		else if (Time.timeSinceLevelLoad > 150)
		{
			waiting = 0.2f;
			speed = Random.Range(10, 7);
		}
		// spawn
    yield return new WaitForSeconds(waiting);
	Vector3 screenPosition = Camera.main.ViewportToWorldPoint(new Vector3(0f, Random.Range(0f, 0.8f), Camera.main.farClipPlane/2));
     GameObject ballsClone = Instantiate(balls, screenPosition, transform.rotation);
	 ballsClone.name = "Balls";
	 balls.GetComponent<Rigidbody2D>().velocity =  balls.transform.right * speed;
	 anim.SetBool("Move", true);
	// yield return new WaitForSeconds(4);
	 // Destroy(ballsClone);
} 
IEnumerator AnimationWait()
{
	yield return new WaitForSeconds(0.2f);
	Destroy(balls);
	AudioBalls.Play();
}
}
