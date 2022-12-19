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

    public static GridManager GridManager
      {
        get
        {
          if(gridManager == null)
          {
            gridManager = GameObject.Find("Grid").GetComponentInParent<GridManager>();
          }
          return gridManager;
        }
      }

    public static ScoreManager ScoreManager
     {
       get
       {
         if(scoreManager == null)
         {
           scoreManager = GameObject.Find("GameManagement").GetComponentInParent<ScoreManager>();
         }
         return scoreManager;

       }
     }

    public static GridLayout GridLayout
    {
      get
      {
        if(gridLayout == null)
        {
          gridLayout = GameObject.Find("Grid").GetComponentInParent<GridLayout>();
        }
        return gridLayout;
      }

    }
    public  static TurnManager TurnManager
    {
      get
      {
        if(turnManager == null)
        {
          turnManager = GameObject.Find("GameManagement").GetComponentInParent<TurnManager>();
        }
        return turnManager;
      }
    }
}
