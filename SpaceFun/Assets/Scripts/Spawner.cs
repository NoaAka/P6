using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject drone;
	public GameObject fighter;
	public Vector3 spawnValues;
	Vector3 spawnPosition;

	//Intensity controls
	public GameObject God;
	int counter;
	public int spawnCount;

	void Start () {
		God = GameObject.FindWithTag ("GameController");
		spawnValues = new Vector3(15f,0f,11f);
	}
	
	void FixedUpdate () {
		if (counter < God.GetComponent<God> ().intensity) {
			Spawn(drone);
			counter = 1000;
		}
		counter--;
	}

	void Spawn (GameObject expectedSpawn){
		spawnCount++;
		//Debug.Log ("Spawning drone #"+spawnCount);
		spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (expectedSpawn, spawnPosition, spawnRotation);
	}
}
