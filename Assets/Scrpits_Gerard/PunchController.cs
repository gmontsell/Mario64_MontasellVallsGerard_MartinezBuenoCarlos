using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchController : MonoBehaviour
{

    [SerializeField] BoxCollider rightPunchCollider;
    [SerializeField] private Animator animator;
    private int numPunch = 0;
    public void setRightPunchTriggerState(bool active)
    {
        rightPunchCollider.enabled = active;
    }

    //FEr Update per mirar si es fa attalk
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && numPunch==0)
        {
            animator.SetTrigger("SinglePunch");
            numPunch++;
        }
        if (Input.GetMouseButtonDown(0) && numPunch == 1)
        {
            animator.SetTrigger("DoublePunch");
            numPunch=0;
        }
    }

    internal void resetNumPunch()
    {
        numPunch = 0;
    }
}
