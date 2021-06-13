using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorChanger : MonoBehaviour
{
    private Vector2 hotSpot = Vector2.zero;
    public Texture2D cursorTexture;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = cursorPos;
    }
}
