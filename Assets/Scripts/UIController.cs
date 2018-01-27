﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {

    public Text uiText;
    public GameObject winScreen;

    void Start () {
        EnemyController.unitInfected += UpdateUI;
    }

    public void UpdateUI() {
        uiText.text = "Infected: " + EnemyController.infectedCount + "/" + EnemyController.enemyCount;
        if (EnemyController.infectedCount == EnemyController.enemyCount) {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
