using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AbilityController))]
public class PlayerController : MonoBehaviour {

    public static PlayerController Instance;
    public AbilityController myAbilityController;

    private Rigidbody2D myRigidbody;
    public Animator myAnimator;
    public AudioSource myAudioSource;

    [SerializeField]
    private float moveSpeed = 10;

    public Vector2 movementVector;

    private bool canShoot = true;


    void Start () {
        Instance = this;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAbilityController = GetComponent<AbilityController>();
        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movementVector != Vector2.zero) {
            myAnimator.SetFloat("input_x", movementVector.x);
            myAnimator.SetFloat("input_y", movementVector.y);

        }

        myRigidbody.velocity = movementVector.normalized * moveSpeed;


        if (Input.GetButtonDown("Jump") && canShoot) {
            myAbilityController.GetInfection().InfectionEffect(this);
            StartCoroutine(AbilityCooldown());
        }
    }
    private IEnumerator AbilityCooldown() {
        canShoot = false;
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
