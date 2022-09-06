using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using static LevelParamaters;
public class ScoreManager : MonoBehaviour
{
    public ProgressBar bloodProgressBar;
    public GameObject LevelCompleteSign;
    public StopWatch stopWatch;

    public int currentScore;

    void Awake()
    {
      bloodProgressBar = GameObject.Find("ProgressBar").GetComponentInParent<ProgressBar>();
      LevelCompleteSign = GameObject.Find("LevelCompleteSign");
      stopWatch = GameObject.Find("StopWatch").GetComponentInParent<StopWatch>();
      LevelCompleteSign.SetActive(false);
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
      if(currentScore >= bloodProgressBar.maximum)
      {
        EndLevel();
      }
    }
    public void StartLevel()
    {
      stopWatch.SetRunning(true);
    }
    public void EndLevel()
    {
      stopWatch.SetRunning(false);
      LevelCompleteSign.SetActive(true);
      GameObject.Find("GameManagement").GetComponentInParent<TurnManager>().EndLevel();
      Debug.Log("Cleared Level");

    }
}
