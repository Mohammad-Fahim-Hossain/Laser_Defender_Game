using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer Instance=null ;
	public AudioClip start;
	public AudioClip Game;
	public AudioClip End;
	private AudioSource Music;

	void Awake(){

		if (Instance != null && Instance !=this) {
			Destroy (gameObject);		
		} else {
			Instance=this;
			GameObject.DontDestroyOnLoad (this.gameObject);
			Music=GetComponent<AudioSource>();
			Music.clip=start;
			Music.loop=true;
			Music.Play();
		}
	}
	void OnLevelWasLoaded(int Level){
		Music.Stop ();
	
		if(Level==0){
			Music.clip = start;

		}
		if(Level==1){
			Music.clip = Game;
			}
		if(Level==2){
			Music.clip = End;
			}
		Music.loop = true;
		Music.Play ();
	
	
	
	}


	// Use this for initialization


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
