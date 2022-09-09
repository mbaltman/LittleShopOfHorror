using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CharacterMover;
using static MovementPatterns;

public class MovementPatternController: MonoBehaviour
{
  public Vector3Int startPosition;
  public bool isPlant;
  public bool isSeymour;
  public bool isMan;
  public bool isAudrey;
  [HideInInspector]
  public CharacterMover mover;
  public List<Vector3Int> moves = new List<Vector3Int >();
  public List<Vector3Int> possibleMoves = new List<Vector3Int>();
  public Vector3Int selectedMove;
  private GridManager gridManager;
    // Start is called before the first frame update

    void Awake()
    {
      gridManager = ServiceLocator.GridManager;

      mover = gameObject.AddComponent(typeof(CharacterMover)) as CharacterMover;
      SetStart();

    }

    public void SelectRandomMove()
    {
      possibleMoves = gridManager.GetAvailableMoves(selectedMove, moves);
      int position =  Random.Range(0, possibleMoves.Count);
      selectedMove = possibleMoves[position] + selectedMove;
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
      mover.MoveTo(selectedMove);
      possibleMoves = gridManager.GetAvailableMoves(selectedMove,moves);
    }

    public void SetMove(Vector3Int updatedSelection)
    {
      selectedMove = updatedSelection;
    }

    public bool MoveComplete()
    {
      return mover.gridLayout.CellToWorld(selectedMove) == transform.position;
    }

    public void SetLevelMovements(int level)
    {
        if(isPlant)
        {
          AddMovement(MovementPatterns.diagonal_1);
          if(level > 1)
          {
            AddMovement(MovementPatterns.adjacent_1);
          }
          if(level > 2)
          {
            AddMovement(MovementPatterns.diagonal_2);
          }

        }
        else if(isSeymour)
        {
          AddMovement(MovementPatterns.diagonal_1);
          AddMovement(MovementPatterns.characters);
          if(level>1)
          {
            AddMovement(MovementPatterns.diagonal_2);
          }
        }
        else if(isMan)
        {
          AddMovement(MovementPatterns.adjacent_1);
          AddMovement(MovementPatterns.characters);

          if(level > 1)
          {
            AddMovement(MovementPatterns.diagonal_1);
          }
        }
        else if(isAudrey)
        {
          AddMovement(MovementPatterns.diagonal_2);
          AddMovement(MovementPatterns.adjacent_2);

        }

        mover.Setup(startPosition);
        selectedMove = startPosition;
        possibleMoves = gridManager.GetAvailableMoves(selectedMove, moves);

    }

    public void SetStart()
    {
      if(isPlant)
      {
        startPosition = new Vector3Int(4,2,0);
      }
      else if(isSeymour)
      {
        startPosition = new Vector3Int(0,4,0);
      }
      else if(isMan)
      {
        startPosition = new Vector3Int(6,2,0);
      }
      else if(isAudrey)
      {
        startPosition = new Vector3Int(6,2,0);
      }
    }
}
