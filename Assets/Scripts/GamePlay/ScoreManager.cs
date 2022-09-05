using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static LevelParamaters;
public class ScoreManager : MonoBehaviour
{
    public ProgressBar bloodProgressBar;

    private int currentScore;

    void Awake()
    {
      bloodProgressBar = GameObject.Find("ProgressBar").GetComponentInParent<ProgressBar>();
    }

    public void SetupLevel(int level)
    {
      currentScore = 0;
      bloodProgressBar.current = currentScore;
      bloodProgressBar.maximum = LevelParamaters.score_goal[level];
    }

    public void IncreaseScore(int delta_score)
    {
      currentScore += delta_score;
      bloodProgressBar.current = currentScore;
      if(currentScore == bloodProgressBar.maximum)
      {
        EndLevel();
      }
    }
    public void EndLevel()
    {
      Debug.Log("Cleared Level");
    }
}
