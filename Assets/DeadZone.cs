using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Muerto");
        HealthSystem_carlitos hs = other.GetComponent<HealthSystem_carlitos>();
        if (hs != null) hs.kill();
    }
}
