using UnityEngine;
using System.Collections;

public class EnemyWall : Enemy {

    public GameObject laserRight, laserLeft;
	
	new void Start () {
		base.Start ();
		cap = 500;
		value = 20;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.forward;
        laserRight = transform.FindChild("LaserRight").gameObject;
        laserLeft = transform.FindChild("LaserLeft").gameObject;
        laserRight.GetComponent<LaserCharge>().damage = (int) damage;
        laserLeft.GetComponent<LaserCharge>().damage = (int)damage;
    }
	
	void Update () {
		Death (damage, value, true);
		//Debug.Log (charge);

		rb.velocity = -transform.forward;
	}
}
