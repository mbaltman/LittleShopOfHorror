using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDripController : MonoBehaviour
{
    private LevelManager levelManager;
    void Awake()
    {
      levelManager = ServiceLocator.LevelManager;
      levelManager.ClearBloodSprite += CheckRemove;
    }

    public void CheckRemove(Vector3 coordinate)
    {
      if(transform.position == coordinate)
      {
        levelManager.ClearBloodSprite -= CheckRemove;
        GameObject.Destroy(gameObject);
      }
    }
}
