using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Assistant : MonoBehaviour{

    private Text messageText;

    private void Awake () {
        
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
    }

    private void Start() {
        Debug.Log(messageText);
        messageText.text = "Hello World";
    }
}
