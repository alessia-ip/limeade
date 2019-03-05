using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED_test_SCR : MonoBehaviour
{
    public GameObject LED_Light;
    public GameObject LED;
    private Renderer LED_Rend;
    private Material LED_Mat;
    public Color LED_Color;

    private void Start()
    {
        LED_Rend = LED.GetComponent<Renderer>();
        LED_Mat = LED_Rend.material;
        LED_Mat.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        if(Input.anyKey){
            LED_Mat.SetColor("_EmissionColor", LED_Color);
            LED_Light.SetActive(true);
        } else {
            LED_Mat.SetColor("_EmissionColor", Color.black);
            LED_Light.SetActive(false);
        }
    }


}
