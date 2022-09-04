using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTileController : MonoBehaviour
{
    bool checkYourself;

    public delegate void TopTileDelegate(Vector3 position);
    public event TopTileDelegate TileSelected;
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

    void OnMouseDown()
    {
      Debug.Log("clicked");

      Vector3 position = transform.position;
      if( TileSelected != null)
      {
          TileSelected(position);
      }
    }

}
