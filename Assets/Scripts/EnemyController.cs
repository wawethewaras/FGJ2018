using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CountPath))]

public class EnemyController : MonoBehaviour {

    public bool infected;
    private SpriteRenderer myRenderer;
    private Rigidbody2D myRigidbody;
    private CountPath myCountPath;

    public Transform[] waypoints;
    private int currentWaypoint;
    public float moveSpeed;

    public GameObject infectingLayer;

    void Start () {
        myRenderer = GetComponent<SpriteRenderer>();
        myCountPath = GetComponent<CountPath>();

        StartCoroutine(moveWayPoints());
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Flu" && !infected) {
            GetInfected();
            Destroy(other.gameObject);
        }
    }

    private IEnumerator moveWayPoints() {
        while((Vector2)transform.position != (Vector2)waypoints[currentWaypoint].position) {
            myCountPath.FindPath(transform, waypoints[currentWaypoint].position);
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
