using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Controller : StateMachineBehaviour
{

    float secondsCounter = 0;
    float secondsToCount = 2;
    float secondsIdelChange = 10;
    private MarioPlayerController marioCont;
   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        marioCont = animator.gameObject.GetComponent<MarioPlayerController>();
        animator.SetBool("IdleCrouch", false);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        secondsCounter += Time.deltaTime;
        if (secondsIdelChange >= secondsCounter && secondsCounter >= secondsToCount)
        {
            marioCont.resetNumJump();
        }
        else if (secondsIdelChange <= secondsCounter)
        {
            secondsCounter =  0.0f;
            animator.SetBool("IdleCrouch",true);
        }
    }
}
