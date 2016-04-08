using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject drone;
	public GameObject wall;
	public GameObject hugger;
	public Vector3 spawnValues;
	Vector3 spawnPosition;
	public bool shouldSpawn = true;

	//Intensity controls
	public GameObject intensity;
	int counter;
	public int spawnCount;
	int d100;

	void Start () {
		intensity = GameObject.Find ("Intensity");
		spawnValues = new Vector3(15f,0f,11f);
	}
	
	void FixedUpdate () {
		if (counter < intensity.GetComponent<Intensity> ().intensity) {
			d100 = Random.Range(1, 100);
			if(d100 > 40 && d100 < 60){
				Spawn (drone);
			}
			else if(d100 < 41){
				Spawn (wall);
			}
			else if(d100 > 59){
				Spawn (hugger);
			}
			counter = 1000;
		}
		counter--;
	}

	void Spawn (GameObject expectedSpawn){
		if (shouldSpawn) {
			spawnCount++;
			//Debug.Log ("Spawning drone #"+spawnCount);
			spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (expectedSpawn, spawnPosition, spawnRotation);
		}

	}
}
