using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
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
        animator.SetBool("openDoor", !animator.GetBool("openDoor"));
    }
}
