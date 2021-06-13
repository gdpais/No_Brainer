using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorChanger : MonoBehaviour
{
    private Vector2 hotSpot;
    public Texture2D cursorTexture;
    // Start is called before the first frame update
    void Start()
    {
        hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
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
