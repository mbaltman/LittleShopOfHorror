using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{

    public GridLayout gridLayout;

    public Vector3Int cellPosition;
    public Vector3Int goalPosition;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool flipped;
    private bool move_north;
    private bool move_east;
    private bool move_south;
    private bool move_west;

    // Start is called before the first frame update
     void Awake()
    {
      gridLayout = GameObject.Find("Grid").GetComponentInParent<GridLayout>();
      spriteRenderer = gameObject.GetComponentInParent<SpriteRenderer>();
      animator = gameObject.GetComponentInParent<Animator>();
      flipped = false;
    }

    void Update()
    {
        CheckMovement();

        spriteRenderer.flipX = flipped;
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("ready"))
        {
          animator.SetBool("reset", false);
          if(move_west)
          {
            animator.SetBool("frontJump", true);
            MoveWest();
          }
          else if(move_east)
          {
            animator.SetBool("frontJump", true);
            MoveEast();
          }
          else if(move_north)
          {
            animator.SetBool("frontJump", true);
            MoveNorth();
          }
          else if(move_south)
          {
            animator.SetBool("frontJump", true);
            MoveSouth();
          }
        }
        else if(animator.GetCurrentAnimatorStateInfo(0).IsTag("done"))
        {
          ResetAnimator();
          animator.SetBool("reset", true);
        }

    }
    private void ResetAnimator()
    {
      animator.SetBool("frontJump", false);
    }

    public void MoveTo(Vector3Int newPosition)
    {
      goalPosition = newPosition;
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

    public void CheckMovement()
    {
      Vector3Int delta = new Vector3Int(0,0,0);
      delta.x = goalPosition.x - cellPosition.x;
      delta.y = goalPosition.y - cellPosition.y;
      move_west = false;
      move_east = false;
      move_north = false;
      move_south = false;

      if(delta.x > 0 )
      {
          move_east = true;
      }
      else if(delta.x < 0)
      {
          move_west = true;
      }

      if(delta.y > 0 )
      {
        move_north = true;
      }
      else if(delta.y < 0)
      {
        move_south= true;
      }
    }

}
