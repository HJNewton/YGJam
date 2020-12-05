using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Player Rotation Settings")]
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float mouseX;
    float mouseY;
    float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime; //Rotation on the X axis
        mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime; //Rotation on the Y axis

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
