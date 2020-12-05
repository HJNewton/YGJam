using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRoomCorridorSnowmanActivate : MonoBehaviour
{
    [Header("Setup")]
    public GameObject snowman;
    public GameObject[] hallwayLights;
    bool hasSpawned;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSpawned)
        {
            StartCoroutine("SpawnSnowman");
            hasSpawned = true;
        }
    }

    IEnumerator SpawnSnowman()
    {
        snowman.SetActive(true);

        foreach (GameObject light in hallwayLights)
        {
            light.GetComponent<Light>().enabled = false;
        }

        yield return new WaitForSeconds(2f);

        snowman.SetActive(false);

        foreach (GameObject light in hallwayLights)
        {
            light.GetComponent<Light>().enabled = true;
        }

        yield break;
    }
}
