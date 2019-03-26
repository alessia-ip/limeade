using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camZoom_SCR : MonoBehaviour
{
    bool complete = false;

    private Camera thisCam;

    bool working = false;

    private void Start()
    {
        thisCam = this.GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.anyKeyDown && complete == false){
            Debug.Log("clicked");
            StartCoroutine(CamZoomNum(50, 2));
            complete = false;
        }
    }

    public IEnumerator CamZoomNum(int zoomAmount, int zoomspeed){
        Debug.Log("started");
        if (working == false){
            working = true;
            for (int i = Mathf.RoundToInt(thisCam.orthographicSize); i >= zoomAmount; i = i - zoomspeed)
            {
                Debug.Log(i);
                thisCam.orthographicSize = i;
                yield return new WaitForSeconds(0.01f);
            }
            working = false;
        }
    }

}
