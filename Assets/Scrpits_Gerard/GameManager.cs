using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<IRestartGame> restartListeners = new List<IRestartGame>();
    public void RestartGame()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RestartGame();
        }
    }

    public void addRestartListener(IRestartGame listener)
    {
        restartListeners.Add(listener);
    }
    public void removeRestartListener(IRestartGame listener)
    {
        restartListeners.Remove(listener);
    }
}
