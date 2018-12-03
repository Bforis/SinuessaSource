using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Shake : MonoBehaviour {

   	public Transform camTransform;
       public GameObject HitZone;
	public float shakeDuration = 0f;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	public GameObject Player;
	
	Vector3 originalPos;
	/* new Camera camera;
	

	void Start()
	{
		camera = GetComponent<Camera>();
	}*/
	void Awake()
	{
		// camera.orthographicSize = Screen.height / 2;
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (GameObject.Find("Player") == null)
		{
        SceneManager.LoadScene("GameOver");
		}
        if (GameObject.Find("Hit1"))
        {
            shakeDuration = 0.5f;
        }
        if (GameObject.Find("Hit"))
        {
			StartCoroutine(Wait());
         //   shakeDuration = 0.2f;
          //  shakeAmount = 0.2f;
        }
      
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(1.4f);
		 shakeDuration = 0.1f;
        shakeAmount = 0.2f;
	}
}