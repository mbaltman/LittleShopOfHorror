using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CharacterMover;
using static MovementPatterns;

public class MovementPatternController: MonoBehaviour
{
  CharacterMover mover;
  public Vector3Int startPosition;
  public bool isPlant;
  List<int []> moves = new List<int [] >();

    // Start is called before the first frame update
    void Start()
    {
      mover = gameObject.AddComponent(typeof(CharacterMover)) as CharacterMover;
      mover.SetPosition(startPosition);
      if(isPlant)
      {
        AddMovement(MovementPatterns.plant_day1_mp);
      }
    }

    public void AddMovement (int [,] newMoves )
    {
      int cols = newMoves.GetLength(0);
      for ( int y = 0; y <cols; y++)
      {
        int [] coordinate = {newMoves[y,0],newMoves[y,1]};
        moves.Add( coordinate );
      }
    }
}
