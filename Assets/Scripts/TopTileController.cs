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
      GameObject.Find("Grid").GetComponent<GridManager>().SelectTile += CheckSelection;
      checkYourself = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(checkYourself)
      {
        GameObject.Find("Grid").GetComponent<GridManager>().DestroyTiles -= CheckYourself;
        GameObject.Find("Grid").GetComponent<GridManager>().SelectTile -= CheckSelection;
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
    public void CheckSelection(Vector3 selected)
    {
      Debug.Log("CheckIfSelected");
      if(transform.position == selected )
      {
        Debug.Log("ADJUST COLOR");
        GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, 1f, 1f);
        Debug.Log(GetComponent<SpriteRenderer>().color);
      }
      else
      {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
      }
    }

}
