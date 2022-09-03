using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{

    private GridLayout gridLayout;

    private Vector3Int cellPosition;
    // Start is called before the first frame update
     void Awake()
    {
      gridLayout = GameObject.Find("Grid").GetComponentInParent<GridLayout>();
      /*
      InvokeRepeating("UpdateInterval",updateInterval,updateInterval);
      */
    }

    public void SetPosition(Vector3Int newPosition)
    {
      cellPosition = newPosition;
      transform.position = gridLayout.CellToWorld(cellPosition);
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
