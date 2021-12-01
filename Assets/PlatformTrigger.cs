using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{

    [SerializeField] Animator animator;

    private GameObject attachedMario=null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MarioPlayerController_carlitos>() != null)
        {
            attachMario(other.gameObject);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<MarioPlayerController_carlitos>() != null)
        {
            dettachMario();
        }
    }

    private void attachMario(GameObject mario)
    {

        mario.transform.parent = transform;
        animator.SetBool("isMarioOn", true);
        attachedMario = mario;
    }

    private void dettachMario()
    {
        if(attachedMario != null)
        {
            attachedMario.transform.parent = transform;
            animator.SetBool("isMarioOn", true);
            attachedMario = null;
        }
       

    }

    private void Update()
    {
       if( Vector3.Angle(transform.up, Vector3.up) > 10)
        {
            dettachMario();
        }
    }
}


