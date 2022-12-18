using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestingEvents : MonoBehaviour
{
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    public class OnSpacePressedEventArgs : EventArgs
    {
        public int spaceCount;
    }

    public event TestEventDelegate OnFloatEvent;
    public delegate void TestEventDelegate(float f);

    public event Action<bool, int> OnActionEvent;

    public UnityEvent OnUnityEvent;
    
    private int spaceCount;

    private void Start()
    {
    }
   
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            //spacebar pressed
        {
            spaceCount++;
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs { spaceCount = spaceCount });

            OnFloatEvent?.Invoke(5.5f);

            OnActionEvent?.Invoke(true, 56);

            OnUnityEvent?.Invoke();
        }   
    }
}
