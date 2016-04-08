using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeZ;//size of plane in game units

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);//it is replacing the parent with the child...
        //print("new pos " + newPosition);
        transform.position = startPosition + Vector3.forward * newPosition;

	
	}
}
