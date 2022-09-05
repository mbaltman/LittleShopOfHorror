using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static LevelParamaters;
public class ScoreManager : MonoBehaviour
{
    public ProgressBar bloodProgressBar;
    public GameObject LevelCompleteSign;

    public int currentScore;

    void Awake()
    {
      bloodProgressBar = GameObject.Find("ProgressBar").GetComponentInParent<ProgressBar>();
      LevelCompleteSign = GameObject.Find("LevelCompleteSign");
      LevelCompleteSign.SetActive(false);
    }

    void Start()
    {

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
    public void EndLevel()
    {
      LevelCompleteSign.SetActive(true);
      GameObject.Find("GameManagement").GetComponentInParent<TurnManager>().EndLevel();
      Debug.Log("Cleared Level");

    }
}
