using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Infection/FoodPoisoning")]
public class FoodPoisoning : Infection
{

    public override void OnEnable()
    {
        infectionID = 1;
    }
    public override void InfectionEffect(PlayerController player)
    {
        Debug.Log("foodPoisoning");

    }
}
