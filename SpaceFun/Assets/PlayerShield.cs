using UnityEngine;
using System.Collections;

public class PlayerShield : MonoBehaviour {
    public float power;
    public float damage;
    public float timeThreshold;//in seconds, how often dealing damage and taking damage

    private Transform playerTransform;
    private Rigidbody playerRb;
    private Rigidbody rb;

    //has to have value of power, has to take damage, has to block particles, has to increase power, has to render, has to give damage
    //has to have a threshold for max damage per .1 sec since being touched over time.... 
    //


	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        playerRb = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        //transform.position = playerTransform.position;
        rb = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       // rb.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
        rb.position = new Vector3(playerRb.position.x, playerRb.position.y, playerRb.position.z);

    }
    void OnCollisionEnter(Collision col)
    {
        print("collision");
        GameObject other = col.collider.gameObject;
        Destroy(other);

    }
}
