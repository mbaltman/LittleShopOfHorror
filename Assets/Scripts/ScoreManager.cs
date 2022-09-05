using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ProgressBar bloodProgressBar;

    private int currentScore;

    void Awake()
    {
      bloodProgressBar = GameObject.Find("ProgressBar").GetComponentInParent<ProgressBar>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetupLevel(int level)
    {
      if(level == 0)
      {
        currentScore = 0;
        bloodProgressBar.maximum = 10;
        bloodProgressBar.current = currentScore;
      }
      if( level == 1)
      {
        currentScore = 0;
        bloodProgressBar.maximum = 10;
        bloodProgressBar.current = currentScore;
      }
    }

    public void IncreaseScore(int delta_score)
    {
      currentScore += delta_score;
      bloodProgressBar.current = currentScore;
    }
}
