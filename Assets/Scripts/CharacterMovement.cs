using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector3 startPosition;
    public GridLayout gridLayout;
    public float updateInterval ;

    private Vector3Int cellPosition;
    // Start is called before the first frame update
    void Start()
    {
      cellPosition = gridLayout.WorldToCell(startPosition);
      transform.position = gridLayout.CellToWorld(cellPosition);
      InvokeRepeating("UpdateInterval",updateInterval,updateInterval);
    }

    // Update is called once per frame
    void UpdateInterval()
    {
      int move_index = Random.Range(0, 4);

      if(move_index==0)
      {
        MoveUp();
      }
      if(move_index==1)
      {
        MoveDown();
      }
      if(move_index==2)
      {
        MoveLeft();
      }
      if(move_index==3)
      {
        MoveRight();
      }
    }

    public void MoveUp()
    {
      cellPosition.y +=1;
      transform.position = gridLayout.CellToWorld(cellPosition);
    }
    public void MoveDown()
    {
      cellPosition.y -=1;
      transform.position = gridLayout.CellToWorld(cellPosition);
    }
    public void MoveRight()
    {
      cellPosition.x +=1;
      transform.position = gridLayout.CellToWorld(cellPosition);
    }
    public void MoveLeft()
    {
      cellPosition.x -=1;
      transform.position = gridLayout.CellToWorld(cellPosition);
    }

}
