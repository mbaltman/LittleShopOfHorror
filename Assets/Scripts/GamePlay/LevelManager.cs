using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using static LevelParamaters;

public class LevelManager : MonoBehaviour
{
    public GameObject bloodDrip_prefab;
    public GameObject seymour_prefab;
    public GameObject man_prefab;
    public GameObject dentist_prefab;
    public GameObject audrey_prefab;
    public GameObject box_prefab;
    public GameObject wire_prefab;

    private List<Vector3Int> bloodDrip_coord;
    private List<Vector3Int> box_coord;
    private List<Vector3Int> wire_coord;
    private GameObject currNewObject;
    private GridLayout gridLayout;
    private MovementPatternController plant;
    private ScoreManager scoreManager;

    public delegate void LevelDelegate(Vector3 coordinate);
    public event LevelDelegate ClearBloodSprite;

    private List<GameObject> characters;

    void Awake()
    {
      gridLayout = ServiceLocator.GridLayout;
      scoreManager = ServiceLocator.ScoreManager;

      plant = GameObject.Find("plant").GetComponentInParent<MovementPatternController>();
      characters = new List<GameObject>();
      bloodDrip_coord = new List<Vector3Int>();
      box_coord = new List<Vector3Int>();
      wire_coord = new List<Vector3Int>();
    }

    public void GenerateLevel( int level)
    {
      ClearLevel();
      GenerateCoordinates(level,LevelParamaters.num_blood[level],ref bloodDrip_coord);
      GenerateCoordinates(level,LevelParamaters.num_boxes[level],ref box_coord);
      GenerateCoordinates(level,LevelParamaters.num_wires[level],ref wire_coord);
      GenerateCharacters(level);
      scoreManager.SetupLevel(level);
    }

    public void DisplayLevel()
    {
      DisplayObjects(ref bloodDrip_prefab, ref bloodDrip_coord );
      DisplayObjects(ref box_prefab, ref box_coord );
      DisplayObjects(ref wire_prefab, ref wire_coord );

      scoreManager.StartLevel();
    }

    public void DisplayObjects(ref GameObject prefab, ref List<Vector3Int> coordinates)
    {
      foreach (Vector3Int coordinate in coordinates)
      {
        currNewObject = Instantiate(prefab, gridLayout.CellToWorld(coordinate), Quaternion.identity);
        //currNewObject.GetComponent<BloodDripController>().Setup(gameObject.GetComponent<LevelManager>());
      }

    }
    public void ClearLevel()
    {

      bloodDrip_coord.Clear();
      box_coord.Clear();
      characters.Clear();
    }

    public Vector3Int CoordinateGenerator(int level)
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
      if(box_coord.IndexOf(currSpace) != -1)
      {
        returnVal = "box";
      }
      else if(bloodDrip_coord.IndexOf(currSpace) != -1)
      {
        returnVal = "eat";
      }
      else if(plant.startPosition == currSpace)
      {
        returnVal = "plant";
      }
      else if(wire_coord.IndexOf(currSpace) != -1)
      {
        returnVal = "wire";
      }
      foreach (GameObject character in characters)
      {
        if(character != null)
        {
          if(currSpace == character.GetComponent<MovementPatternController>().selectedMove)
          {
            returnVal = "eat";
          }
        }
      }
      return returnVal;
    }

    public void ClearSpace(Vector3Int currSpace)
    {
      if(bloodDrip_coord.IndexOf(currSpace) != -1 )
      {
        ClearBlood(currSpace);
      }
      ClearCharacters(currSpace);
    }


    public void CharactersCrouch(Vector3Int currSpace)
    {
      foreach (GameObject character in characters)
      {
        if(currSpace == character.GetComponent<MovementPatternController>().selectedMove)
        {
          character.GetComponent<MovementPatternController>().mover.Crouch();
        }
      }
    }

    public void GenerateCoordinates(int level, int num_object, ref List<Vector3Int> coordinates)
    {
      Vector3Int newCoord = new Vector3Int();
      string space = "";

      for(int i =0; i< num_object; i++)
      {
        newCoord = CoordinateGenerator(level);
        space = CheckSpace(newCoord);
        if(space == "blank")
        {
          coordinates.Add(newCoord);
        }
        else
        {
          i --;
        }
      }


    }


    public void ClearBlood(Vector3Int currSpace)
    {
      //check if the plant is stepping on the blood
      if(plant.mover.cellPosition == currSpace)
      {
        scoreManager.IncreaseScore(1);
        if(ClearBloodSprite != null)
        {
          ClearBloodSprite(gridLayout.CellToWorld(currSpace));
        }

        bloodDrip_coord.Remove(currSpace);
      }
    }

    public void GenerateCharacters(int level)
    {
      GameObject newCharacter;


      for(int i = 0; i < LevelParamaters.num_seymour[level]; i++)
      {
        newCharacter = Instantiate(seymour_prefab);
        newCharacter.GetComponentInParent<MovementPatternController>().SetLevelMovements(level);
        newCharacter.GetComponentInParent<MovementPatternController>().SelectRandomMove();
        newCharacter.GetComponentInParent<MovementPatternController>().Move();
        newCharacter.GetComponentInParent<MovementPatternController>().SelectRandomMove();
        newCharacter.GetComponentInParent<MovementPatternController>().Move();
        characters.Add(newCharacter);
      }

      for(int i = 0; i < LevelParamaters.num_audrey[level]; i++)
      {
        newCharacter = Instantiate(audrey_prefab);
        newCharacter.GetComponentInParent<MovementPatternController>().SetLevelMovements(level);
        newCharacter.GetComponentInParent<MovementPatternController>().SelectRandomMove();
        newCharacter.GetComponentInParent<MovementPatternController>().Move();
        newCharacter.GetComponentInParent<MovementPatternController>().SelectRandomMove();
        newCharacter.GetComponentInParent<MovementPatternController>().Move();
        characters.Add(newCharacter);
      }

      for(int i = 0; i < LevelParamaters.num_men[level]; i++)
      {
        newCharacter = Instantiate(man_prefab);
        newCharacter.GetComponentInParent<MovementPatternController>().SetLevelMovements(level);
        newCharacter.GetComponentInParent<MovementPatternController>().SelectRandomMove();
        newCharacter.GetComponentInParent<MovementPatternController>().Move();
        newCharacter.GetComponentInParent<MovementPatternController>().SelectRandomMove();
        newCharacter.GetComponentInParent<MovementPatternController>().Move();
        characters.Add(newCharacter);
      }

      for(int i = 0; i < LevelParamaters.num_dentist[level]; i++)
      {
        newCharacter = Instantiate(dentist_prefab);
        newCharacter.GetComponentInParent<MovementPatternController>().SetLevelMovements(level);
        newCharacter.GetComponentInParent<MovementPatternController>().SelectRandomMove();
        newCharacter.GetComponentInParent<MovementPatternController>().Move();
        newCharacter.GetComponentInParent<MovementPatternController>().SelectRandomMove();
        newCharacter.GetComponentInParent<MovementPatternController>().Move();
        characters.Add(newCharacter);
      }

    }

    public void MoveCharacters()
    {
      foreach(GameObject character in characters)
      {
        character.GetComponent<MovementPatternController>().SelectRandomMove();
        character.GetComponent<MovementPatternController>().Move();
      }
    }

    public bool CharacterMovesComplete()
    {
      bool returnVal = true;
      foreach(GameObject character in characters)
      {
        if(!character.GetComponent<MovementPatternController>().MoveComplete())
        {
          returnVal = false;
        }
      }
      return returnVal;
    }
    public void ClearCharacters(Vector3Int currSpace)
    {
      List<GameObject> eaten = new List<GameObject>();
      foreach (GameObject character in characters)
      {
        if(currSpace == character.GetComponent<MovementPatternController>().selectedMove)
        {
          eaten.Add(character);
          scoreManager.IncreaseScore(3);
        }
      }
      foreach(GameObject characterEaten in eaten)
      {
        Debug.Log("DESTROY THIS HUMAN");
        characters.Remove(characterEaten);
        Destroy(characterEaten);
      }
      eaten.Clear();
    }

    public void NextLevel()
    {
      Debug.Log("NEXT LEVEL");
      int currLevel = PlayerPrefs.GetInt("level");
      int nextLevel = currLevel + 1;
      PlayerPrefs.SetInt("level",nextLevel);
      SceneManager.LoadScene(sceneBuildIndex:LevelParamaters.next_scene_index[currLevel]);
    }
}
