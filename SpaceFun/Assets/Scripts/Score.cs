using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public int score = 0;
	private Text myText;

	void Start()
	{
		myText = GetComponent<Text>();
		Reset();
	}
		
	public void AddPoints(int points)
	{
		score += points;
		myText.text = "Score : "+ score.ToString();
	}
	public void Reset()
	{
		score = 0;
		myText.text = "Score : "+score.ToString();
	}

}