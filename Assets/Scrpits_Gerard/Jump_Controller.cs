using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Controller : StateMachineBehaviour
{

    float secondsCounter = 0;
    float secondsToCount = 2;
    float secondsIdelChange = 10;
    private MarioPlayerController marioCont;
    private PunchController punchCont;

   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        marioCont = animator.gameObject.GetComponent<MarioPlayerController>();
        punchCont = animator.gameObject.GetComponent<PunchController>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        secondsCounter += Time.deltaTime;
        if (secondsIdelChange >= secondsCounter && secondsCounter >= secondsToCount)
        {
            marioCont.resetNumJump();
            punchCont.resetNumPunch();
        }
        else if (secondsIdelChange <= secondsCounter)
        {
            Debug.Log("Change Idle");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
