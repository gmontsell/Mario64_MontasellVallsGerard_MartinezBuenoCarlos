using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayerController_carlitos : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private CharacterController controller;
    private bool onGround;

    private float verticalSpeed = 0.0f;
    private void Update()
    {

        Vector3 movement = Vector3.zero;
        verticalSpeed += Physics.gravity.y * Time.deltaTime;
        movement.y += verticalSpeed * Time.deltaTime;

        CollisionFlags cf = controller.Move(movement);

        if((cf & CollisionFlags.Below) != 0)
        {
            onGround = true;
            verticalSpeed = -2.0f;

        }
        else
        {
            onGround = false;
        }
       animator.SetBool("onGround", onGround);
       
    }
}
