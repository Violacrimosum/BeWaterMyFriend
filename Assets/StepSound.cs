using UnityEngine;
using System.Collections;

public class StepSound : MonoBehaviour {


	private int actualStep = 0;
	private float delayTime = 0.5f;
	private float actualDelay = 0;

	public AudioClip step1, step2, step3, step4,wallStep;

	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find("Capsule").GetComponent<FPSWalkerEnhanced>().state == 1)
		{
			delayTime = 0.4f;
			runSound();
		}
		else if(GameObject.Find("Capsule").GetComponent<FPSWalkerEnhanced>().state == 2 || GameObject.Find("Capsule").GetComponent<FPSWalkerEnhanced>().state ==4)
		{
			delayTime = 0.3f;
			runSound();
		}
	}

	void runSound(){
		actualDelay += Time.deltaTime;
		
		if(actualDelay>=delayTime)
		{
			actualDelay = 0;
			actualStep = (int)Mathf.Floor(Random.Range(1, 5));
			switch (actualStep)
			{
			case 1:
				audio.clip = step1;
				break;
			case 2:
				audio.clip = step2;
				break;
			case 3:
				audio.clip = step3;
				break;
			case 4:
				audio.clip = step4;
				break;
			default:
				audio.clip = new AudioClip();
				break;
			}
			if(GameObject.Find("Capsule").GetComponent<FPSWalkerEnhanced>().state == 4)
			{
				audio.volume=0.7f;
				audio.clip = wallStep;
			}
			else{
				audio.volume = 1;
			}
			audio.Play ();
		}
	}
}
