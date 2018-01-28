using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerController : MonoBehaviour
{


    public SinkController[] sinks;

    private bool SinksDisabled;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void DisableSinks()
    {
        foreach (SinkController sink in sinks)
        {
            sink.activated = false;
        }
    }

    void EnableSinks()
    {
        foreach (SinkController sink in sinks)
        {
            sink.activated = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!SinksDisabled && other.GetComponent<PlayerController>())
        {
            UIController.Instance.ChangeUITutorial("Press left-click to destroy sinks!");
            if (Input.GetButtonDown("Fire1"))
            {
                DisableSinks();
                SinksDisabled = true;
                UIController.Instance.ChangeUITutorial("");

            }
        }
    }
}
