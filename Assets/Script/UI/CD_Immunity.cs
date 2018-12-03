using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CD_Immunity : MonoBehaviour {

public GameObject Player;
	public Image CoolDown;
	public float Timer = 5f;
	void Start () {
		// timeleft = Timer;
	}
	
	// Update is called once per frame
	void Update () {
		// Vector3 Pos = new Vector3(0.85f, 0.85f, Player.transform.position.z);
		// this.transform.position = Camera.main.ViewportToWorldPoint(Pos);
		/*  if (Input.GetButtonDown("immu") && CoolDown.fillAmount == 1)
		{
			CoolDown.fillAmount = 0;
			if (CoolDown.fillAmount == 0)
			{
				for ()
CoolDown.fillAmount +=  0.2f * Time.deltaTime;
			}
		}*/
		StartCoroutine(Cooldown());
		if (CoolDown.fillAmount < 1)
		{
			CoolDown.color = Color.black;
		}
		else
		{
			CoolDown.color = Color.yellow;
		}
	}
// Barre de CoolDown Immunity
	IEnumerator Cooldown()
	{
		if (Input.GetButtonDown("immu") && CoolDown.fillAmount == 1)
		{
			CoolDown.fillAmount = 0;
			if (CoolDown.fillAmount == 0)
			{
				while (CoolDown.fillAmount < 1)
				{
				yield return new WaitForSeconds(1);
CoolDown.fillAmount +=  0.2f ;
				}

			}
	}
}
}

