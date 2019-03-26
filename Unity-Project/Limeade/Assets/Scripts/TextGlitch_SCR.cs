using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGlitch_SCR : MonoBehaviour
{

    float i;

    public Outline thisOutline;

    void Start()
    {
        StartCoroutine(Glitch());        
    }

    IEnumerator Glitch(){
        i = Random.Range(0.5f, 3);
        int xInt = Random.Range(20, 70);
        int yInt = Random.Range(5, 50);
        yield return new WaitForSeconds(i);
        thisOutline.effectDistance = new Vector2(xInt, 1);
        yield return new WaitForSeconds(0.1f);
        thisOutline.effectDistance = new Vector2(1, yInt);
        yield return new WaitForSeconds(0.1f);
        thisOutline.effectDistance = new Vector2(1, 1);
        StartCoroutine(Glitch());
    }
}
