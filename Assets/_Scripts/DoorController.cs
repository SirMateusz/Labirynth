using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool isOpen = false;

    [SerializeField]
    private Animator animator;

    public void OpenDoors()
    {
        isOpen = !isOpen;

        animator.SetBool("isOpen", isOpen);
    }
}
