using System.Collections;
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
    private SpriteRenderer myRenderer;
    private Rigidbody2D myRigidbody;
    private CountPath myCountPath;

    public Transform[] waypoints;
    private int currentWaypoint;
    public float moveSpeed;

    public GameObject infectingLayer;
    int sprite;
    public enum States {
        Idle,
        Walking,
        Coughing,
        Dead
    }
    private States currentState;
    void Start () {
        myRenderer = GetComponent<SpriteRenderer>();
        sprite = UnityEngine.Random.Range(0, unitDataBase.unitSprites.Length);
        myRenderer.sprite = unitDataBase.unitSprites[sprite];
        myCountPath = GetComponent<CountPath>();
        currentState = States.Walking;
        enemyCount++;
        UnitInfected();
    }
    Vector2 pos;

    IEnumerator moving;

    void Update () {
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
                myRenderer.sprite = unitDataBase.unitDeadSprites[sprite];
                myCountPath.StopMovement();
                break;
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Flu" && !infected) {
            GetInfected();
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

    public void GetInfected() {
        infected = true;
        infectedCount++;
        UnitInfected();
        StartCoroutine(Die());
        myRenderer.color = Color.green;
        infectingLayer.SetActive(true);
    }

    public void GetCured()
    {
        infected = false;
        infectedCount--;
        UnitInfected();
        myRenderer.color = Color.white;
        infectingLayer.SetActive(false);
    }

    public void UnitInfected() {
        if (unitInfected != null) {
            unitInfected();
        }
    }

    public IEnumerator Die() {
        yield return new WaitForSeconds(4f);
        if (infected) {
            StopCoroutine(moving);
            currentState = States.Dead;
        }
    }
}
