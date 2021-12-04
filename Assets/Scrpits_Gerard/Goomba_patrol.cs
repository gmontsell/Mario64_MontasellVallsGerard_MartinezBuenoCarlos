using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goomba_patrol : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] private Animator anim;
    [SerializeField] private Goomba_Follow nextStep;

    private bool startTarget = true;

    private void Start()
    {
        navMesh.destination = startPoint.position;
    }

    private void Update()
    {
        if (startTarget && navMesh.remainingDistance<=0.2)
        {
            startTarget = false;
            navMesh.destination = endPoint.position;
        }
        else if(!startTarget && navMesh.remainingDistance <= 0.2)
        {
            startTarget = true;
            navMesh.destination = startPoint.position;
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("Alert",true);
            nextStep.enabled = true;
            this.enabled = false;
        }
    }
}
