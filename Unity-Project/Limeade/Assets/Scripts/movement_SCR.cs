using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_SCR : MonoBehaviour
{
    [HideInInspector]
    public Transform spawn;

    private bool isAlive = true;

    public GameObject spawnObj;

    public float speed;

    private Rigidbody rb;

    private bool isGrounded;

    //animation
    public Animator anim;

    private Component[] meshComp;

    int cardinalW = 1000;
    int cardinalA = 1000;
    int cardinalS = -1000;
    int cardinalD= -1000;


    public AudioSource mainAudio;

    public AudioClip deathByPit;
    public AudioClip deathByEnemy;
    public AudioClip checkpoint;
    public AudioClip OS;

    void Start()
    {

        spawn = spawnObj.transform;

        rb = GetComponent<Rigidbody>();

        meshComp = GetComponentsInChildren<SkinnedMeshRenderer>();

        //animation
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if(isGrounded == true){
            //animation
            if (Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.DownArrow) == true || Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.D) == true)
            {

                //animation
                anim.SetBool("isWalking", true);
                anim.SetFloat("Direction", 1);

            }
            else
            {

                //animation stop
                anim.SetBool("isWalking", false);

            }
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag == "Ground"){
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        if (isAlive == true && isGrounded == true){
            if (Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.W))
            {
                Vector3 relativePos = new Vector3(this.transform.position.x + cardinalW, 0, 0) - this.transform.position;
                this.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                rb.velocity = transform.forward.normalized * speed;
            }
            else if (Input.GetKey(KeyCode.DownArrow) == true || Input.GetKey(KeyCode.S))
            {
                Vector3 relativePos = new Vector3(this.transform.position.x + cardinalS, 0, 0) - this.transform.position;
                this.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                rb.velocity = transform.forward.normalized * speed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.A))
            {
                Vector3 relativePos = new Vector3(0, 0, this.transform.position.z + cardinalA) - this.transform.position;
                this.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                rb.velocity = transform.forward.normalized * speed;
            }
            else if (Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.D))
            {
                Vector3 relativePos = new Vector3(0, 0, this.transform.position.z + cardinalD) - this.transform.position;
                this.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
                rb.velocity = transform.forward.normalized * speed;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "DeathPit"){
            mainAudio.PlayOneShot(deathByPit);
            isAlive = false;
            foreach(SkinnedMeshRenderer rend in meshComp){
                rend.enabled = false;
            }
            StartCoroutine(Respawn());
        } else if (collision.collider.tag == "enemy"){
            mainAudio.PlayOneShot(deathByEnemy);
            isAlive = false;
            foreach (SkinnedMeshRenderer rend in meshComp)
            {
                rend.enabled = false;
            }
            StartCoroutine(Respawn());
        }


        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "DeathPit"){
            mainAudio.PlayOneShot(deathByPit);
            isAlive = false;
            foreach (SkinnedMeshRenderer rend in meshComp)
            {
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

    public void setNewSpawn(){
        spawn = spawnObj.transform;
    }

}
