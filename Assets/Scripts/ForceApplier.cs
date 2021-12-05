using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplier : MonoBehaviour
{
    [SerializeField]private Rigidbody bridgeRB;
    [SerializeField]private float m_BridgeForce;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Bridge")) {
            bridgeRB.AddForceAtPosition(-hit.normal * m_BridgeForce, hit.point);
        }
    }
}
