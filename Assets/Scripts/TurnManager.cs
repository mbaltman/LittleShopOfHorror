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


    void Awake()
    {
      gridManager = GameObject.Find("Grid").GetComponentInParent<GridManager>();
      levelManager = GameObject.Find("GameManagement").GetComponentInParent<LevelManager>();
      plant = GameObject.Find("plant").GetComponentInParent<MovementPatternController>();
    }

    // Start is called before the first frame update
    void Start()
    {
      gridManager.DisplayMoves(plant.mover.goalPosition, plant.possibleMoves);
      levelManager.GenerateLevel(0);
      levelManager.DisplayLevel();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
        plant.SetMove(gridManager.selectedMove);
        state = levelManager.CheckSpace(gridManager.selectedMove);
        Debug.Log(state);
      }
      if (Input.GetKeyDown(KeyCode.Return))
       {
         gridManager.UnDisplayMoves();
         plant.Move();
       }
      else if(plant.MoveComplete())
      {
        gridManager.DisplayMoves(plant.mover.goalPosition, plant.possibleMoves);
      }
     }

}
