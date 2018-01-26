using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    public static PlayerController Instance;

    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float moveSpeed = 10;

    private Vector2 movementVector;


    public GameObject coughParticle;
    void Start () {
        Instance = this;
        myRigidbody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        myRigidbody.velocity = movementVector.normalized * moveSpeed;


        if (Input.GetButtonDown("Jump")) {
            Coughing();
        }
    }

    private void Coughing() {
        Debug.Log("Cough");
        if (movementVector == Vector2.zero) {
            return;
        }
        Rigidbody2D cough = Instantiate(coughParticle, transform.position, transform.rotation).GetComponent<Rigidbody2D>();
        cough.velocity = movementVector * 15;
    }
}
