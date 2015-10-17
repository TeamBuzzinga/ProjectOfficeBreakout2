/*
Team Buzzinga

Author: Dingfeng Shao

Member: Aaron Quek; David Chang; Ryan Anderson;	Siddharth
*/
using UnityEngine;
using System.Collections;

public class DS_box : MonoBehaviour {

	// Use this for initialization
	AudioSource _audio;
	void Start () {
		_audio = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.gameObject.CompareTag ("Player")) {
			if (!_audio.isPlaying) {
				_audio.Play ();
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
