using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayerController : MonoBehaviour, IRestartGame
{
    [Header ("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform initialPost;
    [SerializeField] private GameManager_Carlitos gameManager;
    
    [Header("Controls")]
    [SerializeField] private KeyCode forwardKey = KeyCode.W;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    [SerializeField] private KeyCode backKey = KeyCode.S;
    [SerializeField] private KeyCode runKey = KeyCode.LeftShift;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;



    [Header ("Jump")]
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private int numJump = 0;

    private bool onGround;
    private float verticalSpeed = 0.0f;
    private void OnEnable()
    {
        //gameManager.addRestartListener(this);
    }
    private void OnDisable()
    {
       // gameManager.removeRestartListener(this);
    }
    private void Update()
    {
        Vector3 movment = Vector3.zero;
       

        Vector3 l_forward = cam.transform.forward;
        l_forward.y = 0.0f;
        l_forward.Normalize();
        Vector3 l_right = cam.transform.right;
        l_right.y = 0.0f;
        l_right.Normalize();

        if (Input.GetKey(forwardKey)) movment += l_forward;
        else if (Input.GetKey(backKey)) movment -= l_forward;
        if (Input.GetKey(rightKey)) movment += l_right;
        if (Input.GetKey(leftKey)) movment -= l_right;
        float currentSpeed = Input.GetKey(runKey) ? runSpeed : walkSpeed;
        if (movment.magnitude > 0)
        {
            movment.Normalize();
            transform.forward = movment;
            animator.SetFloat("Speed", currentSpeed);
            movment *= currentSpeed * Time.deltaTime;
        }
        if(movment.x==0 && movment.z == 0) animator.SetFloat("Speed", 0);


        if (Input.GetKeyDown(jumpKey) && onGround) jump();

        verticalSpeed += Physics.gravity.y * Time.deltaTime;
        movment.y += verticalSpeed * Time.deltaTime;

        CollisionFlags cf = characterController.Move(movment);
        if ((cf & CollisionFlags.Below) !=0)
        {
            onGround = true;
            verticalSpeed = -2.0f;
        }
        else
        {
            if ((cf & CollisionFlags.Above) != 0 && verticalSpeed>0)verticalSpeed=0;
                onGround = false;
        }
        animator.SetBool("onGround", onGround);
        animator.SetFloat("verticalSpeed", verticalSpeed);
    }

    private void jump()
    {
        if (numJump==0)
        {
            verticalSpeed = jumpSpeed;
            animator.SetTrigger("Jump");
            numJump++;
        }
        else if (numJump==1)
        {
            verticalSpeed = jumpSpeed+1;
            animator.SetTrigger("DoubleJump");
            numJump++;
        }
        else if (numJump==2)
        {
            verticalSpeed = jumpSpeed+2;
            animator.SetTrigger("TripleJump");
            numJump=0;
        }
    }
    public void resetNumJump()
    {
        numJump = 0;
    }

    public void RestartGame()
    {
        transform.position = initialPost.position;
        transform.rotation = initialPost.rotation;
    }
}
