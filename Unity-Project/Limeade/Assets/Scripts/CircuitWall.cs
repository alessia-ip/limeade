using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitWall : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();

    }

 private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            animator.SetBool("Deform", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("Deform", false);
        }
    }
}
