using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCam_SCR : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }
}
