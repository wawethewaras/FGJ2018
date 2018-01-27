﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour {

    public static GameController Instance;
    public int fieldInfectd;

    public List<DeadEnemy> deadEnemies = new List<DeadEnemy>();
    public List<GameObject> bodyDropOff = new List<GameObject>();

    void Awake() {
        Instance = this;
    }
    void Start() {
        EnemyController.unitInfected += YardInfected;
    }

    public void YardInfected() {
        if (EnemyController.infectedCount > fieldInfectd) {
            print("Doors open!");
        }
    }

    public bool AllCorpsesTargeted() {
        for (int i = 0; deadEnemies.Count > i; i++) {
            if (deadEnemies[i].isTargeted == false) {
                return false;
            }
        }
        return true;
    }

    public EnemyController GetRandomDead() {
        if (deadEnemies.Count < 1) {
            return null;
        }
        int random = UnityEngine.Random.Range(0,deadEnemies.Count);
        while (deadEnemies[random].isTargeted) {
            random = UnityEngine.Random.Range(0, deadEnemies.Count);
            if (AllCorpsesTargeted()) {
                return null;
            }
        }
        deadEnemies[random].isTargeted = true;
        return deadEnemies[random].enemy;
    }
    public GameObject BodyDropOff()
    {
        if (bodyDropOff.Count < 1)
        {
            return null;
        }
        int random = UnityEngine.Random.Range(0, bodyDropOff.Count);
        return bodyDropOff[random];
    }
}
[Serializable]
public class DeadEnemy {
    public EnemyController enemy;
    public bool isTargeted;

    public DeadEnemy(EnemyController _enemy) {
        enemy = _enemy;
        isTargeted = false;
    }
}