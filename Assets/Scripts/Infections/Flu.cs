using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



[CreateAssetMenu(menuName = "Infection/Flu")]
public class Flu : Infection {
    public GameObject coughParticle;

    public override void InfectionEffect(PlayerController player)
    {
        Debug.Log("Cough");
        if (player.movementVector == Vector2.zero)
        {
            return;
        }
        Rigidbody2D cough = Instantiate(coughParticle, player.transform.position, player.transform.rotation).GetComponent<Rigidbody2D>();
        cough.velocity = player.movementVector * 15;
    }
}
