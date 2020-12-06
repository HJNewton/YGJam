﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleRadio : MonoBehaviour
{
    [Header("Radio Settings")]
    public AudioSource audioSource;
    public float toggleRadius;
    public Text interactTextUI;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        interactTextUI = GameObject.FindGameObjectWithTag("InteractText").GetComponent<Text>();
    }

    private void Update()
    {
        Toggle();
    }

    void Toggle()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, toggleRadius); // Get all overlapping colliders with this object

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    audioSource.enabled = !audioSource.enabled;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
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
        Gizmos.DrawWireSphere(transform.position, toggleRadius);
    }
}
