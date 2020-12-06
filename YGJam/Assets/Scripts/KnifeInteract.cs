using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeInteract : MonoBehaviour
{
    [Header("Knife Setup")]
    public float interactRange;
    public Text interactTextUI;
    public GameObject player;
    public GameObject mainCam;
    public GameObject snowman;
    bool interacted;

    Animator animator;
    
    private void Start()
    {
        interactTextUI = GameObject.FindGameObjectWithTag("InteractText").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");

        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        Interact();
    }

    void Interact()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactRange); // Get all overlapping colliders with this object

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.F) && !interacted)
                {
                    animator.SetTrigger("Kill");
                    player.GetComponent<PlayerController>().enabled = false;
                    mainCam.GetComponent<MouseLook>().enabled = false;
                    interacted = true;

                    StartCoroutine("KillPlayer");
                }
            }
        }
    }

    IEnumerator KillPlayer()
    {
        yield return new WaitForSecondsRealtime(3);
        player.GetComponent<PlayerController>().TurnAround();

        this.GetComponent<MeshRenderer>().enabled = false;

        snowman.SetActive(true);
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
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
