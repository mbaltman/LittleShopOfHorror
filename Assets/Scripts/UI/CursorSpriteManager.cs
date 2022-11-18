using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CursorSpriteManager : MonoBehaviour
{
    public Texture2D cursor_click;
    public Texture2D cursor_normal;
    Vector2 hotspot = new Vector2(30,30);
    
    void Awake()
    {
        Cursor.SetCursor(cursor_normal, hotspot, CursorMode.Auto);
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursor_click, hotspot, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(cursor_normal, hotspot, CursorMode.Auto);
    }

     private void ChangedActiveScene(Scene current, Scene next)
    {
       Cursor.SetCursor(cursor_normal, hotspot, CursorMode.Auto);
    }

}