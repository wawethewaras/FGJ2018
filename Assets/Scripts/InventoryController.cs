using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {


    public bool ratPoison;
    public int keyCount;


    void Start () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (ratPoison && other.tag == "Food")
        {
            print("Press x to put rat poison!");
        }

        if (other.tag == "Key") {
            keyCount++;
            Destroy(other.gameObject);
        }
    }
}

