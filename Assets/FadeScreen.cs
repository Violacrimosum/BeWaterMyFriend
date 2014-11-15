using UnityEngine;
using System.Collections;

public class FadeScreen : MonoBehaviour {


	public float fadeSpeed = 0.005f;
	public bool isFinished = false;
	public bool isFadeText = false;

	void Awake()
	{
		guiTexture.pixelInset = new Rect(-Screen.width/2,-Screen.height/2,Screen.width,Screen.height);
	}
	
	
	void fadeToWhite()
	{
		guiTexture.color = Color.Lerp (guiTexture.color, Color.white,0.0045f);
	}

	void doFadeText()
	{
		isFadeText=true;
		//gameObject.Find("fadeText").guiText.color =  Color.Lerp (, Color.black,0.0045f);
	}
	
	void endScene()
	{
		fadeToWhite();
		if(guiTexture.color.a >= 0.5f)
		{

			guiTexture.color = new Color(1,1,1,1);
			doFadeText();

			//Return to main menu
		}
	}

	void Update()
	{
		isFinished = GameObject.Find("Capsule").GetComponent<FPSWalkerEnhanced>().finished;

		if(isFinished)
		{
			endScene ();
		}
	}
}
