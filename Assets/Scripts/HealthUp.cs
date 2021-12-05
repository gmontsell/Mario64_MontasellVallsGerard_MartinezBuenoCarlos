using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{

    [SerializeField] HealthSystem hs;


    private void OnTriggerEnter(Collider other)
    {
        hs.HealthUp();

        Destroy(gameObject);
    }


}
