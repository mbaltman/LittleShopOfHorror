using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public MovementPatternController plant;
    private GridManager gridManager;
    private bool display;
    private string state;

    // Start is called before the first frame update
    void Start()
    {
      gridManager = GameObject.Find("Grid").GetComponentInParent<GridManager>();
      plant = GameObject.Find("plant").GetComponentInParent<MovementPatternController>();
      gridManager.DisplayMoves(plant.mover.cellPosition, plant.possibleMoves);
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
        plant.SetMove(gridManager.selectedMove);
      }
      if (Input.GetKeyDown(KeyCode.Return))
       {
         gridManager.UnDisplayMoves();
         plant.Move();
         gridManager.DisplayMoves(plant.mover.cellPosition, plant.possibleMoves);
       }
     }

}
