using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomSnowmanActivate : MonoBehaviour
{
    [Header("Setup")]
    public GameObject snowman;
    public GameObject[] lights;
    public GameObject radio;
    bool hasSpawned;
    GameObject player;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(snowman.activeInHierarchy)
        {
            snowman.transform.LookAt(player.transform.position);
        }
    }

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
        yield return new WaitForSeconds(3f);

        snowman.SetActive(true);
        snowman.transform.LookAt(player.transform.position);
        radio.GetComponent<AudioSource>().pitch = 0.6f;

        foreach (GameObject light in lights)
        {
            light.GetComponent<Light>().enabled = false;
        }

        yield return new WaitForSeconds(1.5f);

        snowman.SetActive(false);
        radio.GetComponent<AudioSource>().pitch = 1f;

        foreach (GameObject light in lights)
        {
            light.GetComponent<Light>().enabled = true;
        }

        yield break;
    }
}
