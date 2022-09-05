using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{

    public GridLayout gridLayout;

    public Vector3Int cellPosition;
    public Vector3Int goalPosition;

    private SpriteRenderer spriteRenderer;
    private LevelManager levelManager;
    private Animator animator;

    private bool flipped;
    private bool move_north;
    private bool move_east;
    private bool move_south;
    private bool move_west;
    public float speed = 1.0f;

    // Start is called before the first frame update
     void Awake()
    {
      gridLayout = GameObject.Find("Grid").GetComponentInParent<GridLayout>();
      spriteRenderer = gameObject.GetComponentInParent<SpriteRenderer>();
      animator = gameObject.GetComponentInParent<Animator>();
      levelManager = GameObject.Find("GameManagement").GetComponentInParent<LevelManager>();
      flipped = false;
      ResetAnimator();
    }

    void Update()
    {
        CheckMovement();
        CheckSpace();
        spriteRenderer.flipX = flipped;
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("ready") && !Jumping())
        {
          animator.SetBool("reset", false);
          if(move_west)
          {
            MoveWest();
          }
          else if(move_east)
          {
            MoveEast();
          }
          else if(move_north)
          {
            MoveNorth();
          }
          else if(move_south)
          {
            MoveSouth();
          }
        }
        else if(animator.GetCurrentAnimatorStateInfo(0).IsTag("jumping"))
        {
          var step =  speed * Time.deltaTime;
          transform.position = Vector3.MoveTowards(transform.position, gridLayout.CellToWorld(cellPosition), step);
        }
        else if(animator.GetCurrentAnimatorStateInfo(0).IsTag("eating"))
        {
          CheckSpace();
          levelManager.CharactersCrouch(cellPosition);

          if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5)
          {
            levelManager.ClearSpace(cellPosition);
          }

        }
        else if(animator.GetCurrentAnimatorStateInfo(0).IsTag("done") )
        {
          ResetAnimator();
          animator.SetBool("reset", true);
        }

    }
    private void ResetAnimator()
    {
      animator.SetBool("frontJump", false);
      animator.SetBool("backJump", false);
      animator.SetBool("eat", false);
      move_west = false;
      move_east = false;
      move_north = false;
      move_south = false;
    }

    private bool Jumping()
    {
      return animator.GetBool("backJump") || animator.GetBool("frontJump");
    }

    public void MoveTo(Vector3Int newPosition)
    {
      goalPosition = newPosition;
    }

    public void MoveNorth()
    {

      flipped = false;
      cellPosition.y +=1;

      animator.SetBool("backJump", true);
    }
    public void MoveSouth()
    {
      animator.SetBool("frontJump", true);
      flipped = true;
      cellPosition.y -=1;
    }
    public void MoveEast()
    {
      animator.SetBool("backJump", true);
      flipped = true;
      cellPosition.x +=1;
    }
    public void MoveWest()
    {
      animator.SetBool("frontJump", true);
      flipped = false;
      cellPosition.x -=1;
    }
    public void CheckSpace()
    {
      string state = levelManager.CheckSpace(cellPosition);

      if(state == "eat" && gameObject.GetComponentInParent<MovementPatternController>().isPlant)
      {
        animator.SetBool("eat", true);
      }
    }
    public void Crouch()
    {
      animator.SetBool("crouch", true);
    }

    public void CheckMovement()
    {
      Vector3Int delta = new Vector3Int(0,0,0);
      delta.x = goalPosition.x - cellPosition.x;
      delta.y = goalPosition.y - cellPosition.y;

      if(delta.x > 0 )
      {
          move_east = true;
      }
      else if(delta.x < 0)
      {
          move_west = true;
      }
      else if(delta.y > 0 )
      {
        move_north = true;
      }
      else if(delta.y < 0)
      {
        move_south= true;
      }
    }

    public void Setup(Vector3Int startPosition)
    {
      cellPosition = startPosition;
      goalPosition = startPosition;
      transform.position = gridLayout.CellToWorld(cellPosition);

    }

    public bool DoneMoving()
    {
      return transform.position == gridLayout.CellToWorld(cellPosition);
    }

}
