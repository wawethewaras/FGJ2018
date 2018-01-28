using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {


    public bool ratPoison;
    public int keyCount;

    private AudioSource player;
    public AudioClip soundOnPickUp;
    public AudioClip soundWhenPoisoning;

    void Start () {
        player = GetComponent<AudioSource>();

    }

    void OnTriggerStay2D(Collider2D other)
    {
        FoodInfectionController foodInfection;
        if (ratPoison && (foodInfection = other.GetComponent<FoodInfectionController>()) && !foodInfection.poisonedFood)
        {
            UIController.Instance.ChangeUITutorial("Press space to poison the food!");
            if (Input.GetButtonDown("Jump")){
                foodInfection.poisonedFood = true;
                foodInfection.myRenderer.color = Color.green;
                UIController.Instance.ChangeUITutorial("");
                player.PlayOneShot(soundWhenPoisoning);

            }
        }

        if (other.tag == "Key") {
            player.PlayOneShot(soundOnPickUp);

            keyCount++;
            UIController.Instance.key.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.tag == "RatPoison")
        {
            player.PlayOneShot(soundOnPickUp);
            ratPoison = true;
            UIController.Instance.ChangeUITutorialForDuration("Rat poison collected!");
            UIController.Instance.ratPoison.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}

