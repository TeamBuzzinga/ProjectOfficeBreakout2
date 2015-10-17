using UnityEngine;
using System.Collections;

public class FastMove : MonoBehaviour
{
	ChangPlayerController Script;
	public GUIText gui;
	private AudioSource audioSource;

	void Start () {
		Script = GetComponent <ChangPlayerController> ();
		//gui = GetComponent<GUIText> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "FasterPlane")
		{
			Script.animSpeed = 4.0f;
			audioSource.clip = Script.boost;
			audioSource.Play();//}
			gui.text = "BOOOST MODE ON!!!!";
		}
	}

	void OnCollisionExit(Collision col) {
		if(col.gameObject.name == "FasterPlane")
		{
			Script.animSpeed = 2.0f;;
			gui.text = "";
		}
	}



}