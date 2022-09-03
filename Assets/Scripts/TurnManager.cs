using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public MovementPatternController plant;
    private GridManager gridManager;
    private bool display;
    private string state ;



    // Start is called before the first frame update
    void Start()
    {
      gridManager = GameObject.Find("Grid").GetComponentInParent<GridManager>();
      plant = GameObject.Find("plant").GetComponentInParent<MovementPatternController>();
      Application.targetFrameRate = 5;
      state = "display";
      //display = true;

    }

    // Update is called once per frame
    void Update()
    {
      if(state == "display")
      {
        Debug.Log( plant.possibleMoves.Count);
        gridManager.DisplayMoves(plant.mover.cellPosition, plant.possibleMoves);
        state = "select";
      }
      else if( state == "select")
      {
        plant.SelectRandomMove();
        state = "move";
      }
      else if(state == "move")
      {
        plant.Move();
        state = "stop";
      }
      else if(state == "stop")
      {
        gridManager.UnDisplayMoves();
        state = "display";
      }
      Debug.Log(state);
    }

}
