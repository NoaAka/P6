using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour {
    private Transform playerTransform;
    private Rigidbody rb;

    //has to have value of power, has to take damage, has to block particles, has to increase power, has to render, has to give damage
    //has to have a threshold for max damage per .1 sec since being touched over time.... 


	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //transform.position = playerTransform.position;
        //rb = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
        print("hello");
    }
}
