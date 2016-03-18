using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;
	public float spawnDelay = 0.5f;


	private bool movingRight = true;
	private float xmin, xmax;

	// Use this for initialization
	void Start ()
	{
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera ));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distanceToCamera ));
		xmax = rightBoundary.x;
		xmin = leftBoundary.x;


		SpawnUntilFull();
		}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
		
	}




	void SpawnEnemies ()
	{
		foreach (Transform child in transform) {//looping through all children
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child; //setting parent to position
		}
	}

	void SpawnUntilFull ()
	{
		Transform freePosition = NextFreePosition ();
		if (freePosition) {//true if not null?!
			GameObject enemy = Instantiate (enemyPrefab, freePosition.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition; //setting parent to position
		}
		if (NextFreePosition())	Invoke("SpawnUntilFull", spawnDelay );
	}


	
	// Update is called once per frame
	void Update () {
		if(movingRight){
			//transform.position += new Vector3(speed*Time.deltaTime,0);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}else{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float rightEdgeOfFormation = transform.position.x + (.5f * width);
		float leftEdgeOfFormation = transform.position.x - (.5f * width);
		if(leftEdgeOfFormation < xmin && !movingRight){
			movingRight = true;
			
		}else if(rightEdgeOfFormation > xmax && movingRight){
			movingRight = false;
		}
		if(AllMemberDead()){
			print("Empty formation");
			SpawnUntilFull();
		}

	}

	Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount == 0){//if position has an element (child)
				return childPositionGameObject;
			}

		}
		return null;
	}


	bool AllMemberDead(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount > 0){
				return false;
			}

		}
		return true;
		
	}
}
