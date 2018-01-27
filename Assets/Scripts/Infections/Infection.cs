using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Infection : ScriptableObject {

    public int infectionID;
    public abstract void OnEnable();
    public abstract void InfectionEffect(PlayerController player);
}
