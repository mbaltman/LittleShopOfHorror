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


    void Awake()
    {
      gridManager = GameObject.Find("Grid").GetComponentInParent<GridManager>();
      levelManager = GameObject.Find("GameManagement").GetComponentInParent<LevelManager>();

      plant = GameObject.Find("plant").GetComponentInParent<MovementPatternController>();
      selected = false;
      movePlant = false;
    }

    // Start is called before the first frame update
    void Start()
    {
      gridManager.DisplayMoves(plant.mover.goalPosition, plant.possibleMoves);
      levelManager.GenerateLevel(1);
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
        Debug.Log(state);
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
}
