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
    public AudioClip lockedSound;
    public AudioClip[] openSounds;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        Open();
    }

    void Open()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, openActivationRadius); // Get all overlapping colliders with this object

        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.CompareTag("Player"))
            {
                if(Input.GetKeyDown(KeyCode.F))
                {
                    if (!isOpened && !isLocked)
                    {
                        animator.SetTrigger("Open");
                        PlayOpenAudio();
                        isOpened = true;
                    }

                    if (isLocked)
                    {
                        PlayLockedAudio();
                    }
                }
            }
        }
    }

    public void PlayOpenAudio()
    { 
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = openSounds[Random.Range(0, openSounds.Length)];
        audio.Play();            
    }

    public void PlayLockedAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = lockedSound;
        audio.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, openActivationRadius);
    }
}
