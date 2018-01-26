using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour {

    private bool infected;
    private SpriteRenderer myRenderer;
    private Rigidbody2D myRigidbody;

    public Transform[] waypoints;
    private int currentWaypoint;
    public float moveSpeed;

    void Start () {
        myRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(moveWayPoints());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Flu" && !infected) {
            print("Infected");
            infected = true;
            myRenderer.color = Color.green;
            Destroy(other.gameObject);
        }
    }

    private IEnumerator moveWayPoints() {
        print(currentWaypoint);
        while((Vector2)transform.position != (Vector2)waypoints[currentWaypoint].position) {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, Time.deltaTime * moveSpeed);
            yield return null;

        }
        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length) {
            currentWaypoint = 0;
            StartCoroutine(moveWayPoints());

        }
        else {
            StartCoroutine(moveWayPoints());

        }

    }
}
