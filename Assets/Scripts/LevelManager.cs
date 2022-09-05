using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject bloodDrip_prefab;

    private List<Vector3Int> bloodDrip_coord;
    private List<Vector3Int> box_coord;
    private int level;
    private GameObject currBloodDrip;
    private GridLayout gridLayout;
    private MovementPatternController plant;

    public delegate void LevelDelegate(Vector3 coordinate);
    public event LevelDelegate ClearBlood;

    void Awake()
    {
      gridLayout = GameObject.Find("Grid").GetComponentInParent<GridLayout>();
      plant = GameObject.Find("plant").GetComponentInParent<MovementPatternController>();
      bloodDrip_coord = new List<Vector3Int>();
      box_coord = new List<Vector3Int>();
    }

    public void GenerateLevel( int levelNew)
    {
      ClearLevel();
      level = levelNew;
      GenerateBlood();
    }

    public void DisplayLevel()
    {
      foreach (Vector3Int coordinate in bloodDrip_coord)
      {
        currBloodDrip = Instantiate(bloodDrip_prefab, gridLayout.CellToWorld(coordinate), Quaternion.identity);
        currBloodDrip.GetComponent<BloodDripController>().Setup(gameObject.GetComponent<LevelManager>());
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
        x = Random.Range(0, 3) * 2;
        y = Random.Range(0, 3) * 2;
        even = Random.Range(0, 2);
        if(x == 6 || y == 6 )
        {
          even = 0;
        }
      }
      else
      {
        x = Random.Range(0, 6);
        y = Random.Range(0, 6);
      }

      Vector3Int newCoord = new Vector3Int (0,0,0);
      newCoord.x = x + even;
      newCoord.y = y + even;

      return newCoord ;
    }

    public string CheckSpace(Vector3Int currSpace)
    {
      string returnVal =  "blank";

      if(bloodDrip_coord.IndexOf(currSpace) != -1 )
      {
        returnVal = "bloodDrip";
      }
      return returnVal;
    }

    public void ClearSpace(Vector3Int currSpace)
    {
      if(bloodDrip_coord.IndexOf(currSpace) != -1 )
      {
        Debug.Log("CLEARING OUT BLOOD");
        ClearBlood(gridLayout.CellToWorld(currSpace));
        bloodDrip_coord.Remove(currSpace);
      }
    }

    public void GenerateBlood()
    {
      Vector3Int newCoord = new Vector3Int();
      int is_new = 0;
      int num_blood = 0;

      if(level == 0 )
      {
        num_blood = 5;
      }
      else if(level == 1)
      {
        num_blood = 10;
      }

      for(int i =0; i< num_blood; i++)
      {
        newCoord = CoordinateGenerator();
        is_new = (bloodDrip_coord.IndexOf(newCoord));
        if(is_new == -1 && newCoord != plant.startPosition)
        {
          bloodDrip_coord.Add(newCoord);
        }
        else
        {
          i --;
        }
      }
    }
}
