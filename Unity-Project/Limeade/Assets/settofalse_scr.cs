using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settofalse_scr : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.DownArrow) == true || Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.D) == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}
