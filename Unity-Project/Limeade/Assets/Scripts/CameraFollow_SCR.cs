using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_SCR : MonoBehaviour
{
    public GameObject playerCharacter;
    private Vector3 characterPosition;
    private Vector3 camPosition;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        characterPosition = playerCharacter.transform.position;
        this.transform.position = new Vector3 (characterPosition.x + offsetX, characterPosition.y + offsetY, characterPosition.z + offsetZ);
    }
}
