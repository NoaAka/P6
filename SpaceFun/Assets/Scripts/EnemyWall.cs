using UnityEngine;
using System.Collections;

public class EnemyWall : Enemy {

    public LaserCharge laserRight, laserLeft;
	
	new void Start () {
		base.Start ();
		cap = 500;
		value = 20;
        damage = 2f;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = -transform.forward;
        laserRight = transform.FindChild("LaserRight").gameObject.GetComponent<LaserCharge>();
        laserLeft = transform.FindChild("LaserLeft").gameObject.GetComponent<LaserCharge>();
        //Debug.Log(transform.FindChild("LaserRight").gameObject.name);
        laserRight.damage = (int)damage;
        laserLeft.damage = (int)damage;
    }
	
	void Update () {
		Death (damage, value, true);
		//Debug.Log (charge);

		rb.velocity = -transform.forward;
	}
}
