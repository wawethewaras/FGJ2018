using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMaskNPCController : EnemyController
{

    private enum GasStates {
        LookingforCorpse,
        CarringCorpse,
        Eat
    }
    private GasStates currentGasState;
    private EnemyController currentEnemy;
    private GameObject bodyDropOff;
    private GameObject food;


    // Update is called once per frame
    public override void Update () {
        switch (currentGasState) {
            case GasStates.LookingforCorpse:
                if (currentEnemy == null) {
                    currentEnemy = GameController.Instance.GetRandomDead();
                }
                if (GameController.CorpseCount < 1)
                {
                    currentGasState = GasStates.Eat;
                }
                if (currentEnemy != null)
                {
                    myCountPath.FindPath(transform, currentEnemy.transform.position);
                }

                break;
            case GasStates.CarringCorpse:
                if (bodyDropOff == null)
                {
                    bodyDropOff = GameController.Instance.BodyDropOff();
                }
                myCountPath.FindPath(transform, bodyDropOff.transform.position);

                break;
            case GasStates.Eat:
                if (food == null)
                {
                    food = GameController.Instance.GetFood();
                }
                myCountPath.FindPath(transform, food.transform.position);
                if (GameController.CorpseCount > 3)
                {
                    currentGasState = GasStates.LookingforCorpse;
                }
                break;
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        //EnemyController enemy;
        if (currentEnemy != null && (currentEnemy == other.GetComponent<EnemyController>()) && currentEnemy.infected && currentGasState == GasStates.LookingforCorpse)
        {
            currentGasState = GasStates.CarringCorpse;
            myRenderer.sprite = unitDataBase.carringThing.GetCarringSprite(sprite, currentEnemy.sprite);

            currentEnemy.gameObject.SetActive(false);
            currentEnemy = null;
        }
        else if (other.GetComponent<BodyDropOff>())
        {
            bodyDropOff = null;
            GameController.CorpseCount--;
            currentGasState = GasStates.LookingforCorpse;
            GetSprite();

        }
    }
}
