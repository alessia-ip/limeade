using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_SCR : MonoBehaviour
{
    [HideInInspector]
    public Transform spawn;

    private bool isAlive = true;

    public GameObject spawnOne;

    public float speed;

    private Rigidbody rb;

    //animation
    public Animator anim;

    private Component[] meshComp;

    int cardinalW = 1000;
    int cardinalA = 1000;
    int cardinalS = -1000;
    int cardinalD= -1000;

    void Start()
    {

        spawn = spawnOne.transform;

        rb = GetComponent<Rigidbody>();

        meshComp = GetComponentsInChildren<SkinnedMeshRenderer>();

        //animation
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //animation
        if(Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.DownArrow) == true || Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.D) == true)
        {

            //animation
            anim.SetBool("isWalking", true);
            anim.SetFloat("Direction", 1);

        } else{

            //animation stop
            anim.SetBool("isWalking", false);

        }

    }


    private void FixedUpdate()
    {
        if (isAlive == true){
            if (Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.W))
            {
                Vector3 relativePos = new Vector3(cardinalW, 0, 0) - this.transform.position;
                this.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                rb.velocity = transform.forward.normalized * speed;
            }
            else if (Input.GetKey(KeyCode.DownArrow) == true || Input.GetKey(KeyCode.S))
            {
                Vector3 relativePos = new Vector3(cardinalS, 0, 0) - this.transform.position;
                this.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                rb.velocity = transform.forward.normalized * speed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.A))
            {
                Vector3 relativePos = new Vector3(0, 0, cardinalA) - this.transform.position;
                this.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                rb.velocity = transform.forward.normalized * speed;
            }
            else if (Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.D))
            {
                Vector3 relativePos = new Vector3(0, 0, cardinalD) - this.transform.position;
                this.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                rb.velocity = transform.forward.normalized * speed;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "DeathPit"){
            isAlive = false;
            foreach(SkinnedMeshRenderer rend in meshComp){
                rend.enabled = false;
            }
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn(){
        yield return new WaitForSeconds(1);
        this.transform.position = spawn.position;
        yield return new WaitForSeconds(0.1f);
        isAlive = false;
        foreach (SkinnedMeshRenderer rend in meshComp)
        {
            rend.enabled = true;
        }
        isAlive = true;
    }

}
