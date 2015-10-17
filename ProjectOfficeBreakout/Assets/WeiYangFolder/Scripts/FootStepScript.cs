using UnityEngine;
using System.Collections;

public class FootStepScript : MonoBehaviour {


	AudioSource aSrc;

	public AudioClip metalSound;
	public AudioClip iceSound;


	// Use this for initialization
	void Start () {
	
		aSrc = GetComponent<AudioSource>();

	}

	void OnTriggerEnter(Collider col)
	{
		print("step");
		if(col.tag == "Metal")
		{
			aSrc.Stop();
			aSrc.PlayOneShot(metalSound);

		}
		else if(col.tag == "Ice")
		{
			aSrc.Stop();
			aSrc.PlayOneShot(iceSound);
		}
	}
}
