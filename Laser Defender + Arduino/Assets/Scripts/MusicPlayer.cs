using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public AudioClip startClip, gameClip, endClip;

	private AudioSource music;

	static MusicPlayer instance = null;
	// Use this for initialization

	void Awake(){
		Debug.Log("Music player Awake "+ GetInstanceID() );

		if(instance != null ){
			Destroy(gameObject ); //duplicate music player self-destructing
			Debug.Log("Music player self destructing");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject );
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
	}

	void OnLevelWasLoaded(int level){
		print("Music Player : loaded level : "+ level );
		music.Stop();

		if(level == 0){
			music.clip = startClip;
		}
		else if(level == 1){
			music.clip = gameClip;
		}
		else if(level == 2){
			music.clip = endClip;
		}
		music.loop = true;
		music.Play();
	}




	void Start () {
		//Debug.Log("Music player Start "+ GetInstanceID() );


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
