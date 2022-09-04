using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{

    public GridLayout gridLayout;

    public Vector3Int cellPosition;

    private SpriteRenderer spriteRenderer;


    private bool flipped;
    // Start is called before the first frame update
     void Awake()
    {
      gridLayout = GameObject.Find("Grid").GetComponentInParent<GridLayout>();
      spriteRenderer = gameObject.GetComponentInParent<SpriteRenderer>();
      flipped = false;
    }

    void Update()
    {
        spriteRenderer.flipX = flipped;
    }

    public void SetPosition(Vector3Int newPosition)
    {
      cellPosition = newPosition;
      transform.position = gridLayout.CellToWorld(cellPosition);
    }

    public void MoveNorth()
    {
      flipped = true;
      cellPosition.y +=1;
      transform.position = gridLayout.CellToWorld(cellPosition);
    }
    public void MoveSouth()
    {
      flipped = true;
      cellPosition.y -=1;
      transform.position = gridLayout.CellToWorld(cellPosition);
    }
    public void MoveEast()
    {
      flipped = false;
      cellPosition.x +=1;
      transform.position = gridLayout.CellToWorld(cellPosition);
    }
    public void MoveWest()
    {
      flipped = false;
      cellPosition.x -=1;
      transform.position = gridLayout.CellToWorld(cellPosition);
    }

    public void MoveTo(Vector3Int newPosition)
    {
      Vector3Int delta = new Vector3Int(0,0,0);
      delta.x = newPosition.x - cellPosition.x;
      delta.y = newPosition.y - cellPosition.y;

      if(delta.x > 0 )
      {
          while(cellPosition.x < newPosition.x)
          {
            MoveEast();
          }
      }
      else if(delta.x < 0)
      {
        while(cellPosition.x > newPosition.x)
        {
          MoveWest();
        }
      }

      if(delta.y > 0 )
      {
        while(cellPosition.y < newPosition.y)
        {
          MoveNorth();
        }
      }
      else if(delta.y < 0)
      {
        while(cellPosition.y > newPosition.y)
        {
          MoveSouth();
        }
      }
    }

}
