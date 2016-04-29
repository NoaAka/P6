using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	private Text myText;
	God god;

	void Start() {
		god = GameObject.FindWithTag ("GameController").GetComponent<God> ();
		myText = GetComponent<Text>();
		Reset();
	}
		
	public void AddPoints(float points) {
		god.score += points;
		myText.text = "Score : "+ god.score.ToString();
	}

	public void Reset()	{
		god.score = 0;
		myText.text = "Score : "+god.score.ToString();
	}

}