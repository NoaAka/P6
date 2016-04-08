using UnityEngine;
using System.Collections;

public class Suicide : MonoBehaviour {

	int deathCount = 0;
	public int delay = 200;

	void FixedUpdate () {
		deathCount++;
		//Debug.Log (deathCount);
		if (deathCount >= delay) {
			Destroy (gameObject);
		}
	}
}
