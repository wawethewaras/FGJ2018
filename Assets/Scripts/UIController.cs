using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {

    public Text uiText;
    
	void Start () {
        EnemyController.unitInfected += UpdateUI;
    }

    public void UpdateUI() {
        uiText.text = "Infected: " + EnemyController.infectedCount + "/" + EnemyController.enemyCount;
    }
}
