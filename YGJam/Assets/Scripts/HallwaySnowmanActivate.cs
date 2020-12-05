using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwaySnowmanActivate : MonoBehaviour
{
    [Header("Setup")]
    public GameObject snowman;
    public GameObject[] hallwayLights;
    OpenDoor openDoorScript;
    bool hasSpawned;

    void Start()
    {
        openDoorScript = this.GetComponent<OpenDoor>();
    }

    private void Update()
    {
        if(openDoorScript.isOpened && !hasSpawned)
        {
            StartCoroutine("SpawnSnowman");
            hasSpawned = true;
        }
    }

    IEnumerator SpawnSnowman()
    {
        yield return new WaitForSeconds(0.5f);

        snowman.SetActive(true);

        foreach (GameObject light in hallwayLights)
        {
            light.GetComponent<Light>().enabled = false;
        }

        yield return new WaitForSeconds(0.75f);

        snowman.SetActive(false);

        foreach (GameObject light in hallwayLights)
        {
            light.GetComponent<Light>().enabled = true;
        }

        yield break;
    }
}
