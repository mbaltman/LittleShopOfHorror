using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private static ServiceLocator instance;
    public static ServiceLocator Instance {get; set;}

    private static LevelManager levelManager;
    private static GridManager gridManager;
    private static GridLayout gridLayout;
    private  static TurnManager turnManager;
    private  static ScoreManager scoreManager;

    //there are no set functions because these variables are read only
    public static LevelManager LevelManager
      {
        get
        {  if( levelManager == null )
          {
            levelManager = GameObject.Find("GameManagement").GetComponentInParent<LevelManager>();
          }
          return levelManager;
        }
      }

    public static GridManager GridManager  {get; set;}
    public static GridLayout GridLayout  {get; set;}
    public  static TurnManager TurnManager  {get; set;}
    public  static ScoreManager ScoreManager  {get; set;}


    void Awake()
    {

    }
}

//in any other script file, anywhere
//MainInterface.instance.someTextObject.text = "Hello world!";
