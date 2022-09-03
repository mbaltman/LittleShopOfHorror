using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTileController : MonoBehaviour
{
    bool checkYourself;
    // Start is called before the first frame update
    void Start()
    {
      GameObject.Find("Grid").GetComponent<GridManager>().DestroyTiles += CheckYourself;
      checkYourself = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(checkYourself)
      {
        GameObject.Destroy(gameObject);
      }

    }

    public void CheckYourself()
    {
      checkYourself = true;
    }
}
