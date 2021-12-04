using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void DieFunction();
public class HealthSystem : MonoBehaviour
{
    [SerializeField] float totalHealth = 80.0f;
    [SerializeField] GameManager gameManager;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject healthImage;
    private float currentHealth = 80.0f;
    private DieFunction die;

    public UnityEvent <float, float> healthChanged;
 
    public void setDieFunction(DieFunction die)
    {
        this.die = die;
    }
   
    public void takeDamage(float value)
    {
        StartCoroutine(showHealthColdown());
        currentHealth -= value;
        healthChanged.Invoke(currentHealth, totalHealth);
        anim.SetTrigger("Hit");
        if (totalHealth <= 0.0f) kill();
    }

    internal void restart()
    {
        totalHealth = currentHealth;
    }
    public void kill()
    {
        anim.SetTrigger("Die");
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
    }
    private IEnumerator showHealthColdown()
    {
        healthImage.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        healthImage.SetActive(false);
    }

}
