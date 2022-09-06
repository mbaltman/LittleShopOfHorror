using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StopWatch : MonoBehaviour
{
  private float runningStartTime = 0f;
  private bool running = true;
  public TMP_Text timerText;
  public TMP_Text timeScoreText;


  void FixedUpdate()
  {
    if(running)
    {
      runningStartTime += Time.fixedDeltaTime;
      timerText.text = string.Format("{0:#}", runningStartTime);
    }
    else
    {
      timeScoreText.text = string.Format("{0:#}", runningStartTime);
    }
  }

  public void SetRunning(bool state)
  {
    running = state;
  }
}
