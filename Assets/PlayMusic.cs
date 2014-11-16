using UnityEngine;
using System.Collections;

public class PlayMusic : MonoBehaviour {


	public AudioClip music1;
	

	void Start(){
		audio.clip = music1;
		audio.volume=0.8f;
		audio.Play ();
	}
	// Update is called once per frame
	void Update () {

	}
}
