using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderManager : MonoBehaviour
{
    [SerializeField] private UnityEvent<Collider> _OnTriggerEnter;
    [SerializeField] private UnityEvent<Collider> _OnTriggerStay;
    private void OnTriggerEnter(Collider other)
    {
        if (_OnTriggerEnter != null)
        {
            _OnTriggerEnter.Invoke(other);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (_OnTriggerStay != null)
        {
            _OnTriggerStay.Invoke(other);
        }
    }
}
