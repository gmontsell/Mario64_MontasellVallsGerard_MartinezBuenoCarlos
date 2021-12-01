using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Score")]
public class Score : ScriptableObject
{

    public float points;
    public void score()
    {
        IScoreManager_carlitos score = DependencyContainer.GetDependency<IScoreManager_carlitos>();
        score.addPoints(points);
    }


}
