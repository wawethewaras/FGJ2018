using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectingControllerEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag != "Healthy") {
            print("Infect");
            other.tag = "";
        }
    }

}
