using UnityEngine;
using System.Collections;

public class PlayMusic2 : MonoBehaviour {

	public AudioClip music1;
	
	
	void Start(){
		audio.clip = music1;
		audio.volume = 0;
		audio.Play ();
	}
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Capsule").GetComponent<FPSWalkerEnhanced>().healthBar>GameObject.Find("Capsule").GetComponent<FPSWalkerEnhanced>().maxHealth*0.7f)
		{
			audio.volume=0.8f;
		}
		else{
			audio.volume=0;
		}
		
	}
}
