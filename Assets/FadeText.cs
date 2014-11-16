using UnityEngine;
using System.Collections;

public class FadeText : MonoBehaviour {
	

	public float fadeSpeed = 0.005f;
	public bool isFinished = false;
	
	
	void fadeToWhite()
	{
		guiText.color = Color.Lerp (guiText.color, Color.black,0.0045f);
	}
	

	
	void endScene()
	{
		fadeToWhite();
		if(guiText.color.a >= 0.7f)
		{
			GameObject.Find("Capsule").GetComponent<FPSWalkerEnhanced>().healthBar = 0;
			guiText.color = new Color(0,0,0,1);
			
			//Return to main menu
		}
	}

	void Start()
	{
		guiText.text = "Congratulations, you are now as pure as the water ...\n\nAnd remember ...\n\nBe water my friend ...";
	}
	
	void Update()
	{

		isFinished = GameObject.Find("fadeScreen").GetComponent<FadeScreen>().isFadeText;

		if(isFinished)
		{
			endScene ();
		}
	}
}
