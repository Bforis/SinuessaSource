using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBras : MonoBehaviour {


    public Vector3 pointB;
   
    IEnumerator Start()
    {
		pointB.x = transform.position.x;
		pointB.y = transform.position.y + 0.4f;
        var pointA = transform.position;
        while(true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
        }
    }
   
    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i= 0.0f;
        var rate= 2.0f/time;
        while(i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}