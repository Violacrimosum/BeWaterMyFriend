using UnityEngine;
using System.Collections;

public class JumpSound : MonoBehaviour {
	

	private int actualStep = 0;
	public AudioClip jumpSound1, jumpSound2;

	
	// Update is called once per frame
	void Upzsqsddate () {
		if(GameObject.Find("Capsule").GetComponent<FPSWalkerEnhanced>().state == 3 && Input.GetKeyDown(KeyCode.Space))
		{
			runSound();
		}
	}
	
	void runSound(){
		actualStep = (int)Mathf.Floor(Random.Range(1, 3));
		switch (actualStep)
		{
		case 1:
			audio.clip = jumpSound1;
			break;
		case 2:
			audio.clip = jumpSound2;
			break;
		default:
			audio.clip = jumpSound1;
			break;
		}
		audio.Play ();
	}
}
