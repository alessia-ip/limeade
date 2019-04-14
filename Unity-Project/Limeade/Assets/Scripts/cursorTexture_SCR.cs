using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorTexture_SCR : MonoBehaviour
{

    public Texture2D cursorTexture;
    public Texture2D cursorTextureDown;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            StartCoroutine(MouseDownClick());
        } 
    }

    private IEnumerator MouseDownClick(){
        Cursor.SetCursor(cursorTextureDown, hotSpot, cursorMode);
        yield return new WaitForSeconds(0.2f);
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

}
