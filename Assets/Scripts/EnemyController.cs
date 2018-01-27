using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CountPath))]

public class EnemyController : MonoBehaviour {

    public UnitDataBase unitDataBase;
    public bool infected;
    private SpriteRenderer myRenderer;
    private Rigidbody2D myRigidbody;
    private CountPath myCountPath;

    public Transform[] waypoints;
    private int currentWaypoint;
    public float moveSpeed;

    public GameObject infectingLayer;

    public enum States {
        Idle,
        Walking,
        Coughing
    }
    private States currentState;
    void Start () {
        myRenderer = GetComponent<SpriteRenderer>();
        int sprite = Random.Range(0, unitDataBase.unitSprites.Length);
        myRenderer.sprite = unitDataBase.unitSprites[sprite];
        myCountPath = GetComponent<CountPath>();
        currentState = States.Walking;


    }
    Vector2 pos;
    // Update is called once per frame
    void Update () {
        switch (currentState) {
            case States.Idle:
                break;

            case States.Walking:
                StartCoroutine(moveWayPoints());
                break;
            case States.Coughing:
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
        Vector2 pos = new Vector2(waypoints[currentWaypoint].position.x + Random.Range(-5, 5), waypoints[currentWaypoint].position.y + Random.Range(-5, 5));

        while ((Vector2)transform.position != pos) {
            myCountPath.FindPath(transform, pos);

            yield return null;

        }
        currentWaypoint = Random.Range(0, waypoints.Length);

        float waitTime = Random.Range(0, 3);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(moveWayPoints());


    }

    public void GetInfected() {
        print("Infected");
        infected = true;
        myRenderer.color = Color.green;
        infectingLayer.SetActive(true);
    }
}
