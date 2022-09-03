using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHoverAnimation : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D normalcursor;


    void OnMouseEnter()
    {
        Debug.Log("enter");
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Debug.Log("enter");
        Cursor.SetCursor(normalcursor, Vector2.zero, CursorMode.Auto);
    }

}