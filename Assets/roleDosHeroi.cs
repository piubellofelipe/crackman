using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class roleDosHeroi : MonoBehaviour {
	
	public Transform[] waypoints;
	int cur = 0;
	public float speed = 0.04f;

	// Update is called once per frame
	void FixedUpdate () {
		Vector2 currentPos = transform.position; // new Vector2((float) Math.Truncate(transform.position.x), (float) Math.Truncate(transform.position.y));
		Vector2 currentWay = waypoints[cur].position; // new Vector2((float) Math.Truncate(waypoints[cur].position.x), (float) Math.Truncate(waypoints[cur].position.y));
		// Debug.Log(currentPos);
		// Debug.Log(currentWay);
		float distance = Vector2.Distance(transform.position, waypoints[cur].position);
		Debug.Log(distance);
		if (Vector2.Distance(transform.position, waypoints[cur].position) > 0.1f){
			Vector2 p = Vector2.MoveTowards(currentPos,
											currentWay,
											speed);
			GetComponent<Rigidbody2D>().MovePosition(p);
		} else {
			Debug.Log("chegay");
			cur = (cur + 1) % waypoints.Length;
		}

		Vector2 dir = waypoints[cur].position - transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}

	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "crackman")
			Destroy(co.gameObject);
	}
}
