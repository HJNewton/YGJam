using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    [Header("Key Settings")]
    public float pickupRadius;
    public GameObject doorToUnlock;
    public GameObject deathDoorKey;
    public GameObject light;
    public Material deathDoorKeyMaterial;
    public bool canBePickedUp;
    public AudioClip[] pickupSounds;

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
                    PlayPickupAudio();
                    deathDoorKey.GetComponent<MeshRenderer>().material = deathDoorKeyMaterial;
                    this.GetComponent<MeshRenderer>().enabled = false;
                    light.GetComponent<Light>().enabled = false;
                    Destroy(gameObject,1);
                }
            }
        }
    }

    public void PlayPickupAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = pickupSounds[Random.Range(0, pickupSounds.Length)];
        audio.Play();
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
