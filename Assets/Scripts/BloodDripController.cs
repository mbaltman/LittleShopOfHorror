using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDripController : MonoBehaviour
{
    private LevelManager levelManager;
    public void Setup(LevelManager levelManagerIn)
    {
      levelManager = levelManagerIn;
      levelManager.ClearBlood += CheckRemove;
    }

    public void CheckRemove(Vector3 coordinate)
    {
      if(transform.position == coordinate)
      {
        levelManager.ClearBlood -= CheckRemove;
        GameObject.Destroy(gameObject);
      }
    }
}
