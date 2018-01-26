using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AbilityController))]
public class PlayerController : MonoBehaviour {

    public static PlayerController Instance;
    public AbilityController myAbilityController;

    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float moveSpeed = 10;

    public Vector2 movementVector;


    void Start () {
        Instance = this;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAbilityController = GetComponent<AbilityController>();

    }

    // Update is called once per frame
    void Update () {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        myRigidbody.velocity = movementVector.normalized * moveSpeed;


        if (Input.GetButtonDown("Jump")) {
            myAbilityController.GetInfection().InfectionEffect(this);
        }
    }


}
