using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldSlider : MonoBehaviour {

	private PlayerControl player;
	public Slider slider;

	void Start () {
		slider = this.GetComponent<Slider> ();
		player = GameObject.FindWithTag ("Player").GetComponent<PlayerControl> ();
	}
	
	
	void Update () {
		slider.value = player.shieldPower;
	}
}
