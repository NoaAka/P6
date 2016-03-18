using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float health = 150f;
	public GameObject projectile;
	public float projectileSpeed = 10f;
	public float shotsPerSecond = 0.5f;
	public int scoreValue = 150;

	public AudioClip fireSound, deathSound;

	private ScoreKeeper scoreKeeper;

	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}



	void Update(){
		float probability = Time.deltaTime * shotsPerSecond;
		if(Random.value < probability) Fire();
		
	}
	void Fire(){
		//Vector3 startPosition = transform.position + new Vector3(0,-1,0);
		GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed );
		AudioSource.PlayClipAtPoint(fireSound, transform.position);

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
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
				Destroy(gameObject);
				scoreKeeper.Score(scoreValue);

	}
}
