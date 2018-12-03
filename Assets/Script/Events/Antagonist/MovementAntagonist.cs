using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAntagonist : MonoBehaviour {

    public Vector3 pointB;
    Animator anim;
    public GameObject Event1;
     public GameObject Event2;
      public GameObject Event3;
       public GameObject Event4;
        public GameObject Event5;
         public GameObject Event6;
   
    IEnumerator Start()
    {
        anim = GetComponent<Animator>();
		pointB.x = transform.position.x;
		pointB.y = transform.position.y + 0.5f;
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

    void Update()
    {
        AnimationTete();
    }
    void AnimationTete()
    {
        if (Event1.activeSelf)
        {
            anim.SetTrigger("Oeil1");
        }
              else if (Event2.activeSelf)
        {
            anim.SetTrigger("Oeil2");
        }
             else if (Event3.activeSelf)
        {
            anim.SetTrigger("Oeil3");
        }
             else if (Event4.activeSelf)
        {
            anim.SetTrigger("Oeil4");
        }
               else if (Event5.activeSelf)
        {
            anim.SetTrigger("Oeil5");
        }
               else if (Event6.activeSelf)
        {
            anim.SetTrigger("Oeil6");
        }
        else
        {
            anim.SetTrigger("ON");
        }
    }

}
 