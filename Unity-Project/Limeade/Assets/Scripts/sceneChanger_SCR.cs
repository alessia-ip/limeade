using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneChanger_SCR : MonoBehaviour
{

    public void SceneChange(){
        Initiate.Fade("SceneOne", new Color (0,0,0), 5);
    }

}
