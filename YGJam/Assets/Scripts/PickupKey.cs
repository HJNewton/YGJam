using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupKey : MonoBehaviour
{
    [Header("Key Settings")]
    public float pickupRadius;
    public GameObject doorToUnlock;
    public GameObject deathDoorKey;
    public GameObject lightGO;
    public Material deathDoorKeyMaterial;
    public bool canBePickedUp;
    public AudioClip[] pickupSounds;
    public Text interactTextUI;

    private void Start()
    {
        interactTextUI = GameObject.FindGameObjectWithTag("InteractText").GetComponent<Text>();
    }

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
                    lightGO.GetComponent<Light>().enabled = false;
                    Destroy(gameObject,1);
                    interactTextUI.enabled = false;
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && canBePickedUp)
        {
            interactTextUI.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactTextUI.enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
