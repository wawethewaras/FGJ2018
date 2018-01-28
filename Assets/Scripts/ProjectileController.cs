using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public int speed = 50;
    public Infection infection;

    public float lifeTime;
    void Start() {
        StartCoroutine(DestroyOverTime());
    }

    // Update is called once per frame
    void Update() {

    }

    private IEnumerator DestroyOverTime() {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
