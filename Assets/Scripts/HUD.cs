using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text score;
    public Image healthUi;
    private void Start()
    {
        DependencyContainer.GetDependency<IScoreManager>()
       .scoreChangedDelegate += updateScore;
    }
    private void OnDestroy()
    {
        DependencyContainer.GetDependency<IScoreManager>()
       .scoreChangedDelegate -= updateScore;
    }
    public void updateScore(IScoreManager scoreManager)
    {
        score.text = "Score: " +
       scoreManager.getPoints().ToString("0");
    }

    public void updateHealth(float currentHealth, float totalHealth)
    {
        Debug.Log(currentHealth);
        healthUi.fillAmount = currentHealth / totalHealth;
    }
}
