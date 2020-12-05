using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public float movementSpeed = 10f;
    private Vector3 movementInput;

    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 playerForward = transform.forward;
        Vector3 playerRight = transform.right; 

        movementInput = new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal")); // Get inputs

        Vector3 moveDir = (playerRight * movementInput.z + -playerForward * movementInput.x); // Apply inputs based on player facing direction

        rb.velocity = moveDir.normalized * movementSpeed * Time.deltaTime; // Apply movement
    }
}
