using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOffDeathRoomActivate : MonoBehaviour
{
    [Header("Setup")]
    public GameObject wall;
    public GameObject door;
    AudioSource audioSource;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        wall.SetActive(true);
        door.SetActive(false);
        audioSource.Play();
    }
}
