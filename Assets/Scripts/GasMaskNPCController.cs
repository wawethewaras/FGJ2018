using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasMaskNPCController : EnemyController
{

    private enum GasStates {
        LookingforCorpse,
        CarringCorpse,
    }
    private GasStates currentGasState;
    private EnemyController currentEnemy;
    private GameObject bodyDropOff;

	
	// Update is called once per frame
	void Update () {
        switch (currentGasState) {
            case GasStates.LookingforCorpse:
                if (currentEnemy == null) {
                    currentEnemy = GameController.Instance.GetRandomDead();
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
            currentGasState = GasStates.LookingforCorpse;
            GetSprite();

        }
    }
}
