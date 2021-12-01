using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreManager_carlitos
{
    void addPoints(float f);
    float getPoints();
    event ScoreChanged scoreChangedDelegate;
}
public delegate void ScoreChanged(IScoreManager_carlitos scoreManager);
