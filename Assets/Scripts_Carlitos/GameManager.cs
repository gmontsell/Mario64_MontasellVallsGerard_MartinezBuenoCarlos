using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IRestartGame
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<Transform> chekPoints;
    //[SerializeField] private TextMeshProUGUI textGameOver;

    List<IRestartGame> restartListeners = new List<IRestartGame>();

    private int last_chekPoint;

    //private void Start()
    //{
    //    setLastCheckpoint(0);
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        foreach (IRestartGame l in restartListeners) l.RestartGame();
    }

    public void addRestartListener(IRestartGame Listener)
    {
        restartListeners.Add(Listener);
    }

    public void RemoveRestartListener(IRestartGame Listener)
    {
        restartListeners.Remove(Listener);
    }
    public void gameOver()
    {
        player.GetComponent<CharacterController>().enabled = false;
        //textGameOver.gameObject.SetActive(true);
        Debug.Log("GG");

        if (Input.GetKeyDown(KeyCode.F))
        {
            RestartGame();
        }
    }

    //public void Restart()
    //{
    //    textGameOver.gameObject.SetActive(false);
    //    //textGameOver.gameObject.SetActive(false);

    //    if (last_chekPoint == 0)
    //    {
    //        SceneManager.LoadScene("LevelDesign");
    //    }
    //    else
    //    {
    //        player.GetComponent<HealthSystem_carlitos>().restart();
    //        player.GetComponent<CharacterController>().enabled = false;
    //        player.transform.position = chekPoints[last_chekPoint].position;
    //        player.transform.rotation = chekPoints[last_chekPoint].rotation;
    //        player.GetComponent<CharacterController>().enabled = true;
    //    }


    //}
    //public void setLastCheckpoint(int chekPoint)
    //{
    //    last_chekPoint = chekPoint;
    //}
}
