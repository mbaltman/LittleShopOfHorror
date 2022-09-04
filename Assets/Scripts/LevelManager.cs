using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Constants;

public class LevelManager : MonoBehaviour
{
    public GameObject bloodDrip_prefab;

    private List<Vector3Int> bloodDrip_coord;
    private List<Vector3Int> box_coord;
    private int level;
    private GameObject currBloodDrip;
    private GridLayout gridLayout;

    void Awake()
    {
      gridLayout = GameObject.Find("Grid").GetComponentInParent<GridLayout>();
      bloodDrip_coord = new List<Vector3Int>();
      box_coord = new List<Vector3Int>();
    }

    public void GenerateLevel( int levelNew)
    {
      ClearLevel();
      level = levelNew;

      for(int i =0; i< 5; i++)
      {
        bloodDrip_coord.Add(CoordinateGenerator());
      }
    }

    public void DisplayLevel()
    {
      foreach (Vector3Int coordinate in bloodDrip_coord)
      {
        currBloodDrip = Instantiate(bloodDrip_prefab, gridLayout.CellToWorld(coordinate), Quaternion.identity);
      }
    }

    public void ClearLevel()
    {
      bloodDrip_coord.Clear();
      box_coord.Clear();
    }

    public Vector3Int CoordinateGenerator()
    {
      int x = 0;
      int y = 0;
      int even = 0;

      if(level < 2)
      {
        x = Random.Range(0, 4) * 2;
        y = Random.Range(0, 4) * 2;
        even = Random.Range(0, 2);
        if(x == 6 || y == 6 )
        {
          even = 0;
        }
      }
      else
      {
        x = Random.Range(0, 7);
        y = Random.Range(0, 7);
      }

      Vector3Int newCoord = new Vector3Int (0,0,0);
      newCoord.x = x + even;
      newCoord.y = y + even;
      newCoord -= Constants.GridOffset;

      Debug.Log(newCoord);
      return newCoord ;
    }
}
