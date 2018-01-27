﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkController : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other)
    {
        EnemyController enemy;
        if ((enemy = other.GetComponent<EnemyController>()) && enemy.infected)
        {
            enemy.GetCured();

        }
    }
}