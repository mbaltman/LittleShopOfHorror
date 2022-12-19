using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopTileController : MonoBehaviour
{
    [HideInInspector]
    bool checkYourself;

    public delegate void TopTileDelegate(Vector3 position);
    public event TopTileDelegate TileSelected;
    private GridManager gridManager;

    private bool selected; 
    // Start is called before the first frame update
    public void Setup()
    {
      gridManager = ServiceLocator.GridManager;
      gridManager.DestroyTiles += CheckYourself;
      gridManager.SelectTile += CheckSelection;
      checkYourself = false;
      selected = false; 
    }

    // Update is called once per frame
    void Update()
    {
      if(checkYourself)
      {
        gridManager.DestroyTiles -= CheckYourself;
        gridManager.SelectTile -= CheckSelection;
        GameObject.Destroy(gameObject);
      }
    }

    public void CheckYourself()
    {
      if (!selected)
      {
        checkYourself = true;  
      }
    }

    void OnMouseDown()
    {
      Vector3 position = transform.position;
      if( TileSelected != null)
      {
          TileSelected(position);
      }
    }
    public void CheckSelection(Vector3 selected)
    {
      if(transform.position == selected )
      {
        GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, 1f, 1f);
        this.selected = true; 
      }
      else
      {
        this.selected = false;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
      }
    }

}
