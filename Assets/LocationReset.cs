using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationReset : MonoBehaviour, iRestartGame
{

   [SerializeField] private Transform initPos;
   [SerializeField] private GameManager_Carlitos gameManager;
    public void RestartGame()
    {
        gameManager.RestartGame();
    }


    private void OnEnable()
    {
        gameManager.addRestartListener(this);
    }

    private void OnDisable()
    {
        gameManager.RemoveRestartListener(this);
    }


}
