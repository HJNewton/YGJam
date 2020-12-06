using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [Header("Setup")]
    public Transform playerTransform;
    public float speed;
    [SerializeField ]bool moving;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine("MoveToPlayer");
    }

    private void Update()
    {
        if(moving)
        {
            Movement();
        }
    }

    IEnumerator MoveToPlayer()
    {
        yield return new WaitForSecondsRealtime(2);

        moving = true;
    }

    void Movement()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, playerTransform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManagerScript gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

            gm.GameOver();
        }
    }
}
