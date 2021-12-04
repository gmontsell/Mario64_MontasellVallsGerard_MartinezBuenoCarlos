using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour
{

    [SerializeField] BoxCollider rightPunchCollider;
    [SerializeField] private Animator animator;
    public void setRightPunchTriggerState(bool active)
    {
        rightPunchCollider.enabled = active;
    }

    //FEr Update per mirar si es fa attalk
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("SinglePunch");
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("DoublePunch");
        }
        if (Input.GetMouseButtonDown(2))
        {
            animator.SetTrigger("Kick");
        }
    }
}
