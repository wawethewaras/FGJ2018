using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectingControllerEnemy : MonoBehaviour {

    public EnemyController myEnemy;

    void Start() {
        myEnemy = GetComponentInParent<EnemyController>();
    }

	void OnTriggerStay2D(Collider2D other) {
        EnemyController enemy;
        if ((enemy = other.GetComponent<EnemyController>()) && !enemy.infected) {
            enemy.GetInfected(myEnemy.myInfection);

        }
    }

}
