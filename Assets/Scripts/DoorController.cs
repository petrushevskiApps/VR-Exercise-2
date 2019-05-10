using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator animator;

    public AudioSource doorOpen;
    public AudioSource doorClose;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        AnimateDoor();
    }
    private void OnTriggerExit(Collider other)
    {
        AnimateDoor();
    }

    private void AnimateDoor()
    {
        bool doorReverseState = !animator.GetBool("openDoor");
        animator.SetBool("openDoor", doorReverseState);

        if (doorReverseState) doorOpen.Play();
        else doorClose.Play();
    }
}
