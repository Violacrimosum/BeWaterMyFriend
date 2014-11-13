using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {


	private float health;
	private float maxHealth;


	public GUISkin customSkin;
	public float barDisplay; //current progress
	public Vector2 size = new Vector2(300,50);
	private Vector2 pos = new Vector2();
	public Texture2D emptyTex;
	public Texture2D fullTex;

	void Start(){
		maxHealth = GetComponent<FPSWalkerEnhanced>().maxHealth;
		size = new Vector2(300,50);
		pos = new Vector2(Screen.width/2-size.x/2,Screen.height*0.85f);

	}

	void OnGUI() {
		GUI.skin = customSkin;
		//draw the background:
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
		//draw the filled-in part:
		GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
		GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
		GUI.EndGroup();
		GUI.EndGroup();
	}
	
	// Update is called once per frame
	void Update () {
		health = GetComponent<FPSWalkerEnhanced>().healthBar;
		barDisplay = health/maxHealth;
	}
}
