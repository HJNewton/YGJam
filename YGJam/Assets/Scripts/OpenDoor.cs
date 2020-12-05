using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [Header("Door Setup")]
    public float openActivationRadius;
    public Animator animator;
    public bool isLocked;
    public bool isOpened = false;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isLocked)
        {
            Open();
        }
    }

    void Open()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, openActivationRadius); // Get all overlapping colliders with this object

        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.CompareTag("Player"))
            {
                if(Input.GetKeyDown(KeyCode.F) && !isOpened)
                {
                    animator.SetTrigger("Open");
                    isOpened = true;
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, openActivationRadius);
    }
}
