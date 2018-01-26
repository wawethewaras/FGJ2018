using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyController : MonoBehaviour {

    private bool infected;
    private SpriteRenderer myRenderer;
    void Start () {
        myRenderer = GetComponent<SpriteRenderer>();

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
}
