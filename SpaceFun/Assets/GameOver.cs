using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public God god;
    private Text myText;

    void Start ()
    {
        god = GameObject.FindWithTag("GameController").GetComponent<God>();
        myText = GetComponent<Text>();
        Reset();

    }
    public void Reset()
    {
        myText.text = "";
    }
    public void Toggle(bool on)
    {
        if (on)
        {
            myText.text = "GAME OVER";
            gameObject.GetComponent<Animation>().Rewind("FadeIn");
            gameObject.GetComponent<Animation>().Play("FadeIn");
            ///myText.text = "GAME OVER";
        }
    }
}
