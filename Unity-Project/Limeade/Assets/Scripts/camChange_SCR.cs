using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChange_SCR : MonoBehaviour
{
    public Camera computerCamera;

    public Canvas compCanvas;

    private void Start()
    {
        compCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerCharacter"){
            computerCamera.enabled =  true;
            compCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerCharacter")
        {
            computerCamera.enabled = false;
            compCanvas.enabled = false;

        }
    }

    public void No(){
        computerCamera.enabled = false;
        compCanvas.enabled = false;
    }

}
