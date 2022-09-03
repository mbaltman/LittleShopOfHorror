using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Constants;

public class GridManager : MonoBehaviour
{
    public GameObject toptile_prefab;
    public GridLayout gridLayout;

    public delegate void GridManagerDelegate();
    public event GridManagerDelegate DestroyTiles;

    // Start is called before the first frame update
    void Start()
    {
      gridLayout = GameObject.Find("Grid").GetComponentInParent<GridLayout>();
    }

    public void DisplayMoves(Vector3Int position, List<Vector3Int> moves)
    {
      //go through list
      for(int i = 0; i < moves.Count; i ++)
      {
        Vector3Int currPosition = new Vector3Int(0,0,0);
        currPosition += position;
        currPosition += moves[i];

        //add prefab
        Instantiate(toptile_prefab, gridLayout.CellToWorld(currPosition), Quaternion.identity);
      }
    }

    public void UnDisplayMoves()
    {
      if(DestroyTiles != null)
      {
          DestroyTiles();
      }
    }

    public List<Vector3Int> GetAvailableMoves(Vector3Int position, List<Vector3Int> move)
    {
      List<Vector3Int> availableMoves = new List<Vector3Int>();

      foreach (var coordinate in move)
      {
        if(CheckMove(position,coordinate))
        {
          availableMoves.Add(coordinate);
        }
      }

      return availableMoves;
    }

    public bool CheckMove(Vector3Int position,Vector3Int coordinate)
    {
      Debug.Log("check move");
      Debug.Log(coordinate);
      Vector3Int adjustedCoordinate = coordinate + Constants.GridOffset + position;
      Debug.Log(adjustedCoordinate);
      if(adjustedCoordinate.x  > 6 || adjustedCoordinate.x < 0 || adjustedCoordinate.y > 6 || adjustedCoordinate.y < 0 )
      {
        return false;
      }
      else
      {
        return true;
      }
    }

}
