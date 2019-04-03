using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTexturing_SCR : MonoBehaviour
{

    public Texture[] groundTextures;
    private Renderer thisRenderer;

    // Start is called before the first frame update
    void Start()
    {
        thisRenderer = this.gameObject.GetComponent<Renderer>();
        StartCoroutine(ChangeTexture());
    }


    IEnumerator ChangeTexture(){
//        Debug.Log("Array length =" + groundTextures.Length);
        int i = Random.Range(0, groundTextures.Length);
        Debug.Log(i);
        thisRenderer.material.SetTexture("_MainTex", groundTextures[i]);
        yield return new WaitForSeconds(1);
        StartCoroutine(ChangeTexture());
    }
}
