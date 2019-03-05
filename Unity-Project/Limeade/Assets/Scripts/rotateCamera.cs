using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    private Transform Limon_Transform;
    public GameObject Limon_OBJ;

    // Start is called before the first frame update
    void Start()
    {
        Limon_Transform = Limon_OBJ.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Limon_Transform);
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
