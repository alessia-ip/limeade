using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashlegs_SCR : MonoBehaviour
{

    public GameObject waypointOne;
    public GameObject waypointTwo;

    public int speed;

    int waypointNum = 1;

    private Transform currentWaypoint;

    private void Start()
    {
        currentWaypoint = waypointOne.transform;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == waypointOne.name){
            Debug.Log(1);
            currentWaypoint = waypointTwo.transform;
        } else if (other.name == waypointTwo.name){
            Debug.Log(2);
            currentWaypoint = waypointOne.transform;
        }
    }

    private void move(){
        float distance = Vector2.Distance(this.transform.position, currentWaypoint.position);
      
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);
      
    } 

}
