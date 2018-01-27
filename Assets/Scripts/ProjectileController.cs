﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public int speed = 15;

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
}