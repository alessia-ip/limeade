using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camZoomTrigger : MonoBehaviour
{
    public camZoom_SCR camZoom_;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            Debug.Log("Cam Zoom Trig entered");
            StartCoroutine(camZoom_.CamZoomNum(15, 1));
        }
    }
}
