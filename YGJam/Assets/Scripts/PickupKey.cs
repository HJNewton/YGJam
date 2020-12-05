using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    [Header("Key Settings")]
    public float pickupRadius;
    public GameObject doorToUnlock;
    public GameObject deathDoorKey;
    public Material deathDoorKeyMaterial;
    public bool canBePickedUp;

    private void Update()
    {
        if (canBePickedUp)
        {
            Pickup();
        }
    }

    void Pickup()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRadius); // Get all overlapping colliders with this object

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    UnlockDoor();
                    deathDoorKey.GetComponent<MeshRenderer>().material = deathDoorKeyMaterial;
                    Destroy(gameObject);
                }
            }
        }
    }

    void UnlockDoor()
    {
        doorToUnlock.GetComponent<OpenDoor>().isLocked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
