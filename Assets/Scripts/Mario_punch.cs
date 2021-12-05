using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario_punch : StateMachineBehaviour
{
    float secondsCounter = 0;
    float secondsToStart = 0.3f;
    float secondsToEnd = 0.7f;
    private PunchController punchController;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        punchController = animator.gameObject.GetComponent<PunchController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        secondsCounter += Time.deltaTime;
        punchController.setRightPunchTriggerState(secondsCounter>= secondsToStart && secondsToEnd >= secondsCounter);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        punchController.setRightPunchTriggerState(false);
    }

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
