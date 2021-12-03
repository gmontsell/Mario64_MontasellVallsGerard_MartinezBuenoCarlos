using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void DieFunction();
public class HealthSystem : MonoBehaviour
{
    [SerializeField] float totalHealth = 100.0f;
    [SerializeField] GameManager gameManager;
    private float currentHealth = 100.0f;
    private DieFunction die;

    public UnityEvent <float, float> healthChanged;
 
    public void setDieFunction(DieFunction die)
    {
        this.die = die;
    }
   
    public void takeDamage(float value)
    {
        currentHealth -= value;
        healthChanged.Invoke(currentHealth, totalHealth);

        if (totalHealth <= 0.0f) kill();
    }

    internal void restart()
    {
        totalHealth = currentHealth;
    }
    public void kill()
    {
            totalHealth = 0;
            gameManager.gameOver();
        
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.H))
        {
            takeDamage(totalHealth/8.0f);
        }

        if (currentHealth <= 0)
        {
            kill();
        }
        //if (health <= 0)
        //{
        //    kill();
        //}
    }

 
}