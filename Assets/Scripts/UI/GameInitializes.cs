using UnityEngine;

public class GameInitializes : MonoBehaviour
{
    void Awake()
    {
      PlayerPrefs.SetInt("level", 0);    
    }
}
