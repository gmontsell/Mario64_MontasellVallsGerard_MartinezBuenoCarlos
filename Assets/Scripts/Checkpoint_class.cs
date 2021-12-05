using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_class : MonoBehaviour
{
    [SerializeField] private Transform initPos;
    [SerializeField] private int index;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out MarioPlayerController mario)){
            mario.setCheckpoint(this);
        }

    }

    public Transform getCheckpointTransform()
    {
        return initPos;
    }

    public int getIndex()
    {
        return index;
    }




}
