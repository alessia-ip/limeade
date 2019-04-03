using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChange_SCR : MonoBehaviour
{
    public Camera computerCamera;


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerCharacter"){
            computerCamera.enabled =  true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerCharacter")
        {
            computerCamera.enabled = false;
        }
    }

    public void No(){
        computerCamera.enabled = false;
    }

}
