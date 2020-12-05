using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateKey : MonoBehaviour
{
    [Header("Setup")]
    public GameObject key;
    bool active;
    OpenDoor openDoorScript;

    private void Start()
    {
        openDoorScript = this.GetComponent<OpenDoor>();
    }

    private void Update()
    {
        if (!active)
        {
            if (openDoorScript.isOpened)
            {
                key.GetComponent<PickupKey>().canBePickedUp = true;
                active = true;
            }
        }
    }
}
