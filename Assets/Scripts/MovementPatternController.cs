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

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayMovementOptions()
    {

    }

    public void AddMovement (int [,] newMoves )
    {
      int rows = newMoves.GetLength(1);
      int cols = newMoves.GetLength(0);

    }
}
