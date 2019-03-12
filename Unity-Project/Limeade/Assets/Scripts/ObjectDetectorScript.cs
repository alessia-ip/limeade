using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetectorScript : MonoBehaviour
{

    public GameObject checkpointIndicator;

    private Color spriteColor = new Color(255, 255, 255, 0);

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Checkpoint"){
            //checkpointIndicator.SetActive(true);
            StartCoroutine(FadeIn(checkpointIndicator));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Checkpoint")
        {
            //checkpointIndicator.SetActive(false);
            StartCoroutine(FadeOut(checkpointIndicator));
        }
    }

    IEnumerator FadeIn(GameObject imgObj)
    {
        float i;
        yield return new WaitForSeconds(0.1f);
        for (i = 0; i <= 1.1; i = i + 0.1f)
        {
            spriteColor = new Color(0, 0, 0, i);
            imgObj.GetComponent<SpriteRenderer>().color = spriteColor;
            yield return new WaitForSeconds(0.05f);
        }
        Debug.Log("done");
    }

    IEnumerator FadeOut(GameObject imgObj)
    {
        float i;
        yield return new WaitForSeconds(0.1f);
        for (i = 1.5f; i >= -0.5f; i = i - 0.1f)
        {
            spriteColor = new Color(0, 0, 0, i);
            imgObj.GetComponent<SpriteRenderer>().color = spriteColor;
            yield return new WaitForSeconds(0.05f);
        }
        Debug.Log("done");
    }

}
