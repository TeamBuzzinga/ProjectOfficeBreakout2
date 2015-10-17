using UnityEngine;
using System.Collections;

public class SlowMove : MonoBehaviour
{
	ChangPlayerController Script;
	public GUIText gui;
	private AudioSource audioSource;

	void Start () {
		Script = GetComponent <ChangPlayerController> ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "SlowerPlane")
		{
			//if(!audioSource.isPlaying){
			Script.isIce = true;
				audioSource.clip = Script.ice;
				audioSource.Play();//}
			Script.animSpeed = 0.5f;
			gui.text = "I am on the ice..gotta be careful";
		}
	}
	
	void OnCollisionExit(Collision col) {
		if(col.gameObject.name == "SlowerPlane")
		{
			Script.isIce = false;
			Script.animSpeed = 2.0f;;
			gui.text = "";
		}
	}
	
	
	
}