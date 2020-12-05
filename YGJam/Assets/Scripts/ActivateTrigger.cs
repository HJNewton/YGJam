using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    [Header("Setup")]
    public GameObject trigger;
    PickupKey pickupScript;

    private void Start()
    {
        pickupScript = this.GetComponent<PickupKey>();
    }

    void Update()
    {
        if(pickupScript.canBePickedUp)
        {
            trigger.SetActive(true);
        }
    }

}
