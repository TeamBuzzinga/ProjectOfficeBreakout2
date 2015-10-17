/*
 * Team Name: Team Buzzinga!
 * Script Created by: Siddharth
 * Other Members: Ryan, Dingfeng, Aaron, David
 */
using UnityEngine;
using System.Collections;

public class FootstepsOn : MonoBehaviour {

	public AudioClip walkSound;

	private AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.S)) {
			audio.Play ();
		}
	}
}
