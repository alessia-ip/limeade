using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_SCR : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;


    //animation
    public Animator anim;


    void Start()
    {



        rb = GetComponent<Rigidbody>();


        //animation
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //animation
        if(Input.GetKey(KeyCode.UpArrow) == true){

            //animation
            anim.SetBool("isWalking", true);
            anim.SetFloat("Direction", 1);

        } else if (Input.GetKey(KeyCode.DownArrow)==true){

            //animation
            anim.SetBool("isWalking", true);
            anim.SetFloat("Direction", -1);

        }
        else{

            //animation stop
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBackwards", false);

        }


    }


    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.UpArrow) == true){
            rb.velocity = transform.forward.normalized * speed;
        } else if (Input.GetKey(KeyCode.DownArrow) == true)
        {
           rb.velocity = transform.forward.normalized * speed * -1;
        }

    }



}
