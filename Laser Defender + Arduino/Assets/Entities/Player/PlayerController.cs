using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = .3f;
	public float padding = 1f;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 0.2f;
	public float health = 1000f;

	public AudioClip fireSound;

	float xmin; 
	float xmax;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance ));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance ));
		xmin = leftmost.x + padding; 
		xmax = rightmost.x - padding;
	
	}
	void Fire(){
		//Vector3 offset = new Vector3(0,1,0 );
		GameObject beam = Instantiate(projectile,transform.position,Quaternion.identity) as GameObject;
		//unity 4 : beam.rigidbody2D.velocity = new Vector3(0,projectileSpeed);
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0,projectileSpeed, 0 );
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){//GetKeyDown, for just one press! GetKeyUp is for release a key!
			InvokeRepeating("Fire",0.00001f,firingRate );//calling Fire() every "firingRate" seconds!! 
		}
		if(Input.GetKeyUp(KeyCode.Space )){
			CancelInvoke("Fire");
		}
		
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			//transform.position += new Vector3(-speed*Time.deltaTime,0,0);
			Vector3 newPosition = transform.position + Vector3.left * speed * Time.deltaTime; //Vector3.left is unity vector pointing left  
			float newX = Mathf.Clamp(newPosition.x, xmin, xmax );
			transform.position = new Vector3(newX, transform.position.y, transform.position.z);
		}
		else if(Input.GetKey(KeyCode.RightArrow)){
			//transform.position += new Vector3(+speed*Time.deltaTime,0,0);
			Vector3 newPosition = transform.position + Vector3.right * speed * Time.deltaTime; //Vector3.right is unity vector pointing right 
			float newX = Mathf.Clamp(newPosition.x, xmin, xmax );
			transform.position = new Vector3(newX, transform.position.y, transform.position.z );
		}
		//restrict the player to the gamespace


	}
	void OnTriggerEnter2D(Collider2D col){
		Projectile missile = col.gameObject.GetComponent<Projectile>();//will be null if cannot find component
		if(missile){//when missile is not null
			Debug.Log("Hit by a projectile!");
			health -= missile.GetDamage();
			missile.Hit();
			if(health <= 0){
				Die();
			}
		}
	}
	void Die(){
		LevelManager manager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		Destroy(gameObject);
		manager.LoadLevel("GameOver");
	}
}
