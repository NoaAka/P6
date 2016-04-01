using UnityEngine;
using System.Collections;

public class EdgeDestroy : MonoBehaviour {

	void OnTriggerExit(Collider other){
		Destroy (other.gameObject);
	}
}
