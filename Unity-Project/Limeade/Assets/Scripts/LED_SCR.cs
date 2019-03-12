using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED_SCR : MonoBehaviour
{
    public GameObject LED_Light;
    public GameObject LED;
    private Renderer LED_Rend;
    private Material LED_Mat;
    public Color LED_Color;

    public Color halfway;

    private bool activated = false;

    private void Start()
    {
        LED_Rend = LED.GetComponent<Renderer>();
        LED_Mat = LED_Rend.material;
        LED_Mat.EnableKeyword("_EMISSION");

        halfway = new Color(LED_Color.r/2, LED_Color.g/2, LED_Color.b/2, LED_Color.a/2);
    }

    void Update()
    {
        //    if(Input.anyKey){
        //        LED_Mat.SetColor("_EmissionColor", LED_Color);
        //        LED_Light.SetActive(true);
        //    } else {
        //        LED_Mat.SetColor("_EmissionColor", Color.black);
        //        LED_Light.SetActive(false);
        //    }
        }


        private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ObjectDetector" && activated == false)
        {
            LED_Mat.SetColor("_EmissionColor", halfway);
            LED_Light.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ObjectDetector" && activated == false)
        {
            LED_Mat.SetColor("_EmissionColor", Color.black);
            LED_Light.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "ObjectDetector"){
            if (Input.GetKeyDown(KeyCode.Z) == true)
            {
                LED_Mat.SetColor("_EmissionColor", LED_Color);
                activated = true;
            }
        }
    }

}
