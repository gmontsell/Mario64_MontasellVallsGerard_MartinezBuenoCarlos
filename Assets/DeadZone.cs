using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Muerto");
        HealthSystem hs = other.GetComponent<HealthSystem>();
        if (hs != null) hs.kill();
    }
}
