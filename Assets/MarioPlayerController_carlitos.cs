using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioPlayerController_carlitos : MonoBehaviour, IRestartGame
{
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Camera cam;


    [Header("Jump")]
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float speedJump;

    [Header("Movement")]
    [SerializeField]private KeyCode forwardKey;
    [SerializeField] private KeyCode backKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private KeyCode runKey;
    [SerializeField] private float speedWalk;
    [SerializeField] private float speedRun;

    private bool onGround;
    private float verticalSpeed = 0.0f;


    [SerializeField] GameManager_Carlitos gm;

    private void Update()
    {
       
        Vector3 movement = Vector3.zero;


        if (Input.GetKeyDown(jumpKey)&&onGround)
        {
            jump();  
        }
        Vector3 l_forward = cam.transform.forward;
        l_forward.y = 0.0f;
        l_forward.Normalize();

        Vector3 l_right = cam.transform.right;
        l_right.y = 0.0f;
        l_right.Normalize();


        if (Input.GetKey(forwardKey))
        {
            movement += l_forward;
        }
        if (Input.GetKey(backKey))
        {
            movement -= l_forward;
        }


        if (Input.GetKey(rightKey))
        {
            movement += l_right;
        }
        if (Input.GetKey(leftKey))
        {
            movement -= l_right;
        }
        float currentSpeed = (Input.GetKey(runKey) ? speedRun : speedWalk);
        if (movement.magnitude > 0)
        {
            animator.SetFloat("Speed", currentSpeed);
            movement.Normalize();
            transform.forward = movement;
            movement *= currentSpeed * Time.deltaTime;
     
        }
        

        verticalSpeed += Physics.gravity.y * Time.deltaTime;
        movement.y += verticalSpeed * Time.deltaTime;

        CollisionFlags cf = controller.Move(movement);

        if((cf & CollisionFlags.Below) != 0)
        {
            onGround = true;
            verticalSpeed = -1.0f;

        }
        else
        {
            if ((cf & CollisionFlags.Above) != 0 && verticalSpeed > 0) verticalSpeed = 0;
            onGround = false;
        }
       animator.SetBool("onGround", onGround);
       
    }


    private void jump()
    {
        verticalSpeed = speedJump;
        animator.SetTrigger("Jump");
    }

    private Checkpoint_class currentCheckpoint; 
    public void setCheckpoint(Checkpoint_class checkpoint)
    {
        if(currentCheckpoint == null || currentCheckpoint.getIndex() < checkpoint.getIndex())
        {
            currentCheckpoint = checkpoint;
        }

    }
    private void Start()
    {
        gm.addRestartListener(this);
    }
    private void OnDestroy()
    {
        gm.RemoveRestartListener(this);
    }
    private bool resetPos = false;
    public void RestartGame()
    {
        //resetHealth
        resetPos = true;
       
    }


    private void LateUpdate()
    {
        if (resetPos)
        {
            Transform t = currentCheckpoint.getCheckpointTransform();
            GetComponent<CharacterController>().enabled = false;
            transform.position = t.position;
            transform.rotation = t.rotation;
            resetPos = false;
        }
    }
}
