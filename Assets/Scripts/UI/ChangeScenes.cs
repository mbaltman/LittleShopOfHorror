using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public int sceneToChangeTo;

    void OnMouseDown ()
    {
      Debug.Log("GO TO " + sceneToChangeTo);
      SceneManager.LoadScene(sceneBuildIndex:sceneToChangeTo);
    }
}
