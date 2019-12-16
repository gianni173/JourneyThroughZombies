using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntatoreMouse : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        Vector2 CursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = CursorPos;
    }

}
