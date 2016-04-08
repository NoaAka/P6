using UnityEngine;
using System.Collections;

public class SimpleSpawner : MonoBehaviour {
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        SpawnEnemy();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SpawnEnemy()
    {
        Instantiate(enemy, new Vector3(0f, 0f, 6f), Quaternion.identity);
    }
}
