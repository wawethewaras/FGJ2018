using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {

    public static UIController Instance;
    public Text uiText;
    public Text tutorialText;

    public GameObject winScreen;

    public GameObject ratPoison;
    public GameObject key;


    void Awake() {
        Instance = this;
    }
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

    public void ChangeUITutorial(string text) {
        tutorialText.text = text;
    }
    public void ChangeUITutorialForDuration(string text)
    {
        StartCoroutine(TextForDuration(text));
    }
    public IEnumerator TextForDuration(string text) {
        tutorialText.text = text;
        yield return new WaitForSeconds(2f);
        tutorialText.text = "";

    }


}
