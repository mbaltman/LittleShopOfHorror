using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CharacterMover;
using static MovementPatterns;

public class MovementPatternController: MonoBehaviour
{
  public Vector3Int startPosition;
  public bool isPlant;
  [HideInInspector]
  public CharacterMover mover;
  public List<Vector3Int> moves = new List<Vector3Int >();
  public List<Vector3Int> possibleMoves = new List<Vector3Int>();
  public Vector3Int selectedMove;
  private GridManager gridManager;
  private LevelManager levelManager;

    // Start is called before the first frame update

    void Awake()
    {
      mover = gameObject.AddComponent(typeof(CharacterMover)) as CharacterMover;
      gridManager = GameObject.Find("Grid").GetComponentInParent<GridManager>();
      levelManager = GameObject.Find("GameManagement").GetComponentInParent<LevelManager>();
      mover.SetPosition(startPosition);
      if(isPlant)
      {
        AddMovement(MovementPatterns.plant_day1_mp);
        AddMovement(MovementPatterns.plant_day2_mp);
      }
      possibleMoves = gridManager.GetAvailableMoves(mover.cellPosition, moves);
    }
    void Start()
    {
      possibleMoves = gridManager.GetAvailableMoves(mover.cellPosition, moves);
    }

    public void SelectRandomMove()
    {
      possibleMoves = gridManager.GetAvailableMoves(mover.cellPosition, moves);
      int position =  Random.Range(0, possibleMoves.Count);
      selectedMove = possibleMoves[position] + mover.cellPosition;
    }

    public void AddMovement (int [,] newMoves )
    {
      int cols = newMoves.GetLength(0);
      for ( int y = 0; y <cols; y++)
      {
        Vector3Int coordinate = new Vector3Int(newMoves[y,0] , newMoves[y,1],0);
        moves.Add(coordinate);
      }
    }

    public void Move()
    {
      //right now, it only processes the "last space" but really, it should process every spot it jumps on
      ProcessSpace(levelManager.CheckSpace(selectedMove));

      mover.MoveTo(selectedMove);
      possibleMoves = gridManager.GetAvailableMoves(mover.cellPosition,moves);
    }

    public void SetMove(Vector3Int updatedSelection)
    {
      selectedMove = updatedSelection;
    }
    public void ProcessSpace ( string spaceState )
    {
      Debug.Log(spaceState);
    }
}
