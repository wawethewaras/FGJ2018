using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Infection/Flu")]
public class Flu : Infection {
    public ProjectileController coughParticle;

    public override void OnEnable() {
        infectionID = 0;
    }
    public override void InfectionEffect(PlayerController player)
    {
        Debug.Log("Cough");
        Rigidbody2D cough = Instantiate(coughParticle, player.transform.position, player.transform.rotation).GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(player.myAnimator.GetFloat("input_x"), player.myAnimator.GetFloat("input_y"));
        cough.velocity = direction * coughParticle.speed;
    }
}
