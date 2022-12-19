using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject topTile_prefab;

    [HideInInspector]

    public Vector3Int selectedMove;

    public delegate void GridManagerDelegate();
    public event GridManagerDelegate DestroyTiles;

    public delegate void TileDelegate(Vector3 selected);
    public event TileDelegate SelectTile;

    private GameObject currTile;
    private GridLayout gridLayout;
    private GridManager gridManager;
    private LevelManager levelManager;
    private bool displayed;

    // Start is called before the first frame update
    void Awake()
    {
      gridLayout = ServiceLocator.GridLayout;
      levelManager = ServiceLocator.LevelManager;
      displayed = false;
    }

    public void DisplayMoves(Vector3Int position, List<Vector3Int> moves)
    {
      if(! displayed)
      {
        foreach (Vector3Int currMove  in  moves )
        {

          Vector3Int currPosition = new Vector3Int(0,0,0);
          currPosition += position;
          currPosition += currMove;

          //add prefab
          currTile = Instantiate(topTile_prefab, gridLayout.CellToWorld(currPosition), Quaternion.identity);
          currTile.GetComponent<TopTileController>().Setup();
          currTile.GetComponent<TopTileController>().TileSelected += UpdateSelected;
        }
        displayed = true;
      }
    }

    public void UnDisplayMoves()
    {
      if(DestroyTiles != null)
      {
          DestroyTiles();
      }
      displayed = false;
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
      Vector3Int adjustedCoordinate = coordinate +  position;
      if(adjustedCoordinate.x is > 6 or < 0 )
      {
        return false;
      }

      if(adjustedCoordinate.y is > 6 or < 0 )
      {
        return false;
      }

      var tileContents = levelManager.CheckSpace(adjustedCoordinate);
      if( tileContents is "box" or "wire")
      {
        return false;
      }
      return true;
    }

    private void UpdateSelected(Vector3 position)
    {
      selectedMove = gridLayout.WorldToCell(position);
      if(SelectTile != null)
      {
        SelectTile(position);
      }
    }

}
