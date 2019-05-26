using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D co) {
        // Do Stuff...
        if (co.name == "crackman"){
            Destroy(gameObject);
		}
    }
}
