using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOffDeathRoomActivate : MonoBehaviour
{
    [Header("Setup")]
    public GameObject wall;
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        wall.SetActive(true);
        door.SetActive(false);
    }
}
