using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkController : MonoBehaviour {

    public bool activated = true;

    public GameObject WaterParticles;

    void OnTriggerStay2D(Collider2D other)
    {
        EnemyController enemy;
        if (activated && (enemy = other.GetComponent<EnemyController>()) && enemy.infected)
        {
            enemy.GetCured();

        }
    }
}
