using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public bool locked = false;

    private Animator myAnimator;

	void Start () {
        myAnimator = GetComponent<Animator>();
        CloseDoor();
    }


    public void OpenDoor() {
        locked = false;
        myAnimator.SetBool("Locked", false);
        GetComponent<SpriteRenderer>().enabled = false;

    }
    public void CloseDoor()
    {
        locked = true;
        myAnimator.SetBool("Locked", true);
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        InventoryController player;
        if (locked && (player = other.GetComponent<InventoryController>()) && player.keyCount > 0) {
            player.keyCount--;
            if (player.keyCount <= 0) {
                UIController.Instance.key.SetActive(false);
            }
            OpenDoor();
        }
    }
}
