﻿using System.Collections;
using UnityEngine;
using System;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CountPath))]

public class EnemyController : MonoBehaviour {
    public static int enemyCount = 0;
    public static int infectedCount = 0;
    public static event Action unitInfected;

    public UnitDataBase unitDataBase;
    public bool infected;
    public Infection myInfection;

    protected bool isDead = false;
    protected SpriteRenderer myRenderer;
    protected Rigidbody2D myRigidbody;
    protected CountPath myCountPath;

    public Transform[] waypoints;
    private int currentWaypoint;
    public float moveSpeed;

    public GameObject infectingLayer;
    public int sprite;
    private enum States {
        Idle,
        Walking,
        Coughing,
        Dead
    }
    public enum UnitType
    {
        Standard,
        Mask,
        Gas
    }
    public UnitType unitType;
    private States currentState;

    protected virtual void Start () {
        myRenderer = GetComponent<SpriteRenderer>();
        sprite = UnityEngine.Random.Range(0, unitDataBase.unitSprites.Length);
        GetSprite();
        myCountPath = GetComponent<CountPath>();
        currentState = States.Walking;
        enemyCount++;
        UnitInfected();
    }
    Vector2 pos;

    IEnumerator moving;

    public virtual void Update () {
        switch (currentState) {
            case States.Idle:
                break;

            case States.Walking:
                moving = moveWayPoints();
                StartCoroutine(moving);
                break;
            case States.Coughing:
                break;
            case States.Dead:
                if (!isDead) {
                    GameController.CorpseCount++;
                    myRenderer.sprite = unitDataBase.unitDeadSprites[sprite];
                    myCountPath.StopMovement();
                    GameController.Instance.deadEnemies.Add(new DeadEnemy(this));
                    isDead = true;
                    
                }

                break;
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        ProjectileController influence;
        if ((influence = other.GetComponent<ProjectileController>()) && !infected) {
            GetInfected(influence.infection);
            Destroy(other.gameObject);
        }

    }
    private IEnumerator moveWayPoints() {
        Vector2 pos = new Vector2(waypoints[currentWaypoint].position.x + UnityEngine.Random.Range(-5, 5), waypoints[currentWaypoint].position.y + UnityEngine.Random.Range(-5, 5));

        while ((Vector2)transform.position != pos) {
            myCountPath.FindPath(transform, pos);

            yield return null;

        }
        currentWaypoint = UnityEngine.Random.Range(0, waypoints.Length);

        float waitTime = UnityEngine.Random.Range(0, 3);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(moveWayPoints());


    }

    public void GetInfected(Infection infection) {
        if (infection.infectionID == 0) {
            if (unitType == UnitType.Standard) {
                infected = true;
                infectedCount++;
                myInfection = infection;
                UnitInfected();
                StartCoroutine(Die());
                myRenderer.color = Color.green;
                infectingLayer.SetActive(true);
            }
        }
        if (infection.infectionID == 1) {
            if (unitType == UnitType.Mask || unitType == UnitType.Standard) {
                infected = true;
                infectedCount++;
                myInfection = infection;
                UnitInfected();
                StartCoroutine(Die());
                myRenderer.color = Color.green;
                infectingLayer.SetActive(true);
            }
            if (unitType == UnitType.Gas)
            {
                infected = true;
                infectedCount++;
                myInfection = infection;
                UnitInfected();
                StartCoroutine(Die());
                myRenderer.color = Color.green;
            }
        }

    }

    public void GetCured()
    {
        infected = false;
        infectedCount--;
        UnitInfected();
        myRenderer.color = Color.white;
        infectingLayer.SetActive(false);
    }
    public void GetSprite()
    {
        switch (unitType){
            case UnitType.Standard:
                myRenderer.sprite = unitDataBase.unitSprites[sprite];

                break;
            case UnitType.Mask:
                myRenderer.sprite = unitDataBase.unitMaskSprites[sprite];
                break;
            case UnitType.Gas:
                myRenderer.sprite = unitDataBase.unitGasMaskSprites[sprite];
                break;

        }
    }


    public void UnitInfected() {
        if (unitInfected != null) {
            unitInfected();
        }
    }

    public IEnumerator Die() {
        yield return new WaitForSeconds(5f);
        if (infected) {
            if (moving != null) {
                StopCoroutine(moving);

            }
            currentState = States.Dead;
        }
    }
}
