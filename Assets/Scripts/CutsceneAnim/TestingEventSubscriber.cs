using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEventSubscriber : MonoBehaviour {
    
    private void Start() {
       TestingEvents testingEvents = GetComponent<TestingEvents>();
        testingEvents.OnSpacePressed += TestingEvents_OnSpacePressed;
        testingEvents.OnFloatEvent += TestingEvents_OnFloatEvent;
        testingEvents.OnActionEvent += TestingEvents_OnActionEvent;
    }

    private void TestingEvents_OnActionEvent(bool arg1, int arg2)
    {
        Debug.Log(arg1 + " " + arg2);
    }

    private void TestingEvents_OnFloatEvent(float f)
    {
        Debug.Log("Float:" + f);
    }


    private void TestingEvents_OnSpacePressed(object sender, TestingEvents.OnSpacePressedEventArgs e)
    {
        Debug.Log("SpacePressed" + e.spaceCount);
        
    }

    public void TestingUnityEvents()
    {
        Debug.Log("TestingUnityEvents");
    }
     
    }
 
