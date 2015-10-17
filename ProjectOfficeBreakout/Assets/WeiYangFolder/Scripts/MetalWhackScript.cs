using UnityEngine;
using System.Collections;

public class MetalWhackScript : MonoBehaviour {
	
	
	AudioSource aSrc;

	int i = 0;
	
	public AudioClip metalWhackSound;
	
	// Use this for initialization
	void Start () {
		
		aSrc = GetComponent<AudioSource>();
		
	}
	
	void OnTriggerEnter(Collider obj)
	{
		if(obj.gameObject.name == "Push Sphere")
		{
			aSrc.Stop();
			aSrc.PlayOneShot(metalWhackSound);
		}
	}
}
