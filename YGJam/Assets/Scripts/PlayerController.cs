using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public float movementSpeed = 10f;
    private Vector3 movementInput;
    public AudioClip[] footstepSounds;
    bool walking;

    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        InvokeRepeating("PlayFootstepsAudio", 0, 0.4f);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 playerForward = transform.forward;
        Vector3 playerRight = transform.right; 

        movementInput = new Vector3(-Input.GetAxisRaw("Vertical"), 0f, Input.GetAxisRaw("Horizontal")); // Get inputs

        Vector3 moveDir = (playerRight * movementInput.z + -playerForward * movementInput.x); // Apply inputs based on player facing direction

        rb.velocity = moveDir.normalized * movementSpeed * Time.deltaTime; // Apply movement
        
        if(rb.velocity != Vector3.zero)
        {
            walking = true;
        }

        else
        {
            walking = false;
        }
    }

    public void PlayFootstepsAudio()
    {
        if (walking)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audio.Play();
        }
    }

    public void TurnAround()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, -270, 0));
    }
}
