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


  void FixedUpdate()
  {
    if(running)
    {
      runningStartTime += Time.fixedDeltaTime;
      timerText.text = string.Format("{0:#.00}", runningStartTime);
    }
  }

  public void SetRunning(bool state)
  {
    running = state;
  }
}
