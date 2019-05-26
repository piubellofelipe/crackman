using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cracmanMove : MonoBehaviour {
	public float speed = 5f;
	Vector2 dest = Vector2.zero;

	// Use this for initialization
    void Start() {
        dest = transform.position;
    }

	bool valid(Vector2 dir) {
		// Cast Line from 'next to Pac-Man' to 'Pac-Man'
		Vector2 pos = transform.position;

		RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
		/*
			Note: we simply casted the Line from the point next to Pac-Man (pos + dir)
			to Pac-Man himself (pos).
		 */
		return (hit.collider == GetComponent<Collider2D>());
	}

	void FixedUpdate() {
		// Debug.Log((Vector2)transform.position == dest));
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		Vector2 position = new Vector2(transform.position.x, transform.position.y);
		GetComponent<Rigidbody2D>().MovePosition(p);

		// Check for Input if not moving
		if (position.x == dest.x || position.y != dest.y) {
			if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
				dest = (Vector2)transform.position + Vector2.up;
			if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
				dest = (Vector2)transform.position + Vector2.right;
			if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
				dest = (Vector2)transform.position - Vector2.up;
			if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
				dest = (Vector2)transform.position - Vector2.right;
		}

		Vector2 dir = dest - (Vector2)transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}
}
