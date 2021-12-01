using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class HUD_carlitos : MonoBehaviour
{
    public TextMeshProUGUI score;
 private void Start()
    {
        DependencyContainer.GetDependency<IScoreManager_carlitos>()
       .scoreChangedDelegate += updateScore;
    }
    private void OnDestroy()
    {
        DependencyContainer.GetDependency<IScoreManager_carlitos>()
       .scoreChangedDelegate -= updateScore;
    }
    public void updateScore(IScoreManager_carlitos scoreManager)
    {
        score.text = "Score: " +
       scoreManager.getPoints().ToString("0");
    }
}
