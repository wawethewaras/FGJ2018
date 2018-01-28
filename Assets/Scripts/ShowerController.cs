using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerController : MonoBehaviour
{


    public SinkController[] sinks;

    private AudioSource audioSource;
    public AudioClip soundOnPickUp;

    private bool SinksDisabled;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DisableSinks()
    {
        audioSource.PlayOneShot(soundOnPickUp);
        foreach (SinkController sink in sinks)
        {
            sink.WaterParticles.SetActive(false);
            sink.activated = false;
        }
    }

    void EnableSinks()
    {
        foreach (SinkController sink in sinks)
        {
            sink.WaterParticles.SetActive(true);
            sink.activated = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!SinksDisabled && other.GetComponent<PlayerController>())
        {
            UIController.Instance.ChangeUITutorial("Press space to destroy sinks!");
            if (Input.GetButtonDown("Jump"))
            {
                DisableSinks();
                SinksDisabled = true;
                UIController.Instance.ChangeUITutorial("");

            }
        }
    }
}
