using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goomba_Follow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] private Animator anim;
    [SerializeField] private Goomba_patrol nextStep;

    private bool canAttack=true;
    void Update()
    {
        navMesh.destination = target.position;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("Alert",false);
            nextStep.enabled = true;
            this.enabled = false;
        }
    }

    public void attackTrigger(Collider other)
    {
        if (other.TryGetComponent<HealthSystem>(out HealthSystem hs) && canAttack)
        {
            hs.takeDamage(10);
            StartCoroutine(attackColdown());
        }
    }
    public void Death(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("Death");
            Destroy(gameObject);
        }
    }
    private IEnumerator attackColdown()
    {
        canAttack = false;
        yield return new WaitForSeconds(1.0f);
        canAttack = true;
    }
}
