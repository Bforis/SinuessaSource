using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Raycasting : MonoBehaviour {
private SpriteRenderer rend;
public GameObject Player;
Animator anim;
Collider2D col;
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		col = GetComponent<Collider2D>();
	}
	

	void FixedUpdate () {
		Vector3 PlayerPos = new Vector3(Player.transform.position.x, (Player.transform.position.y - 1f), Player.transform.position.z);
		    RaycastHit2D hit;
			LayerMask playermask = LayerMask.GetMask("Player");
			Vector3 WhereStart_Raycast = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.35f, 0));
			Debug.DrawRay(PlayerPos, WhereStart_Raycast, Color.green);
			hit = Physics2D.Raycast(PlayerPos, (WhereStart_Raycast), playermask);
			if (hit.collider.gameObject.tag == "EVENTDAMAGE")
			{
				rend.sortingLayerName = "PlayerUn";
				Debug.Log("Raycast hit something");
			}
			else if (hit.collider.gameObject.tag == "EVENTNODAMAGE")
			{
				rend.sortingLayerName = "PlayerUn";
				Debug.Log("Raycast hit something");
			}
			else
			{
				rend.sortingLayerName ="PlayerDeux";
			}
	}

	void Fire()
	{
		anim.SetBool("Fire", true);
	}

	void ActiveCollider()
	{
		col.enabled = !col.enabled;
	}
}
