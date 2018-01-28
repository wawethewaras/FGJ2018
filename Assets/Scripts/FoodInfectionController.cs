using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodInfectionController : MonoBehaviour {

    public Infection foodPoison;

    public bool poisonedFood;
    public SpriteRenderer myRenderer;

    void Start() {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        EnemyController enemy;
        if (poisonedFood && (enemy = other.GetComponent<EnemyController>()) && !enemy.infected)
        {
            enemy.GetInfected(foodPoison);

        }
    }
}
