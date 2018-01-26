using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour {

    public Infection[] infections;
    private int currentInfection = 0;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeInfection() {
        currentInfection++;
        if (currentInfection > infections.Length + 1) {
            currentInfection = 0;
        }
    }

    public Infection GetInfection() {
        return infections[currentInfection];
    }
}
