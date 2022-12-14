using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [HideInInspector]
    private MovementPatternController plant;
    private LevelManager levelManager;
    private GridManager gridManager;

    private bool display;
    private string state;
    private bool selected;
    private bool movePlant;
    private bool playing;


    void Awake()
    {
      gridManager = ServiceLocator.GridManager;
      levelManager = ServiceLocator.LevelManager;

      plant = GameObject.Find("plant").GetComponentInParent<MovementPatternController>();

      selected = false;
      movePlant = false;
      enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
      int level = PlayerPrefs.GetInt("level");
      Debug.Log("CURRNET LEVEL: " + level);
      levelManager.GenerateLevel(level);

      plant.SetLevelMovements(level);
      gridManager.DisplayMoves(plant.mover.goalPosition, plant.possibleMoves);
      levelManager.DisplayLevel();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
        plant.SetMove(gridManager.selectedMove);
        state = levelManager.CheckSpace(gridManager.selectedMove);
        selected = true;
      }
      if (Input.GetKeyDown(KeyCode.Return) && selected)
       {
         levelManager.MoveCharacters();
         gridManager.UnDisplayMoves();
         selected = false;
         movePlant = true;
       }
      else if(levelManager.CharacterMovesComplete() && movePlant)
      {
        plant.Move();
        movePlant = false;
      }
      else if(plant.MoveComplete())
      {
        gridManager.DisplayMoves(plant.mover.goalPosition, plant.possibleMoves);
      }
     }
     public void EndLevel()
     {
       gridManager.UnDisplayMoves();
       plant.gameObject.SetActive(false);
       enabled = false;
     }
}
