/*
 * Team Name: Team Buzzinga!
 * Script Created by: Siddharth
 * Other Members: Ryan, Dingfeng, Aaron, David
 */

using UnityEngine;
using System.Collections;

public class WaterSound : MonoBehaviour {

	public AudioClip waterSplash;
	public AudioClip waterWalk;
	public Transform waterEffect;

	private AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();	
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}

	void OnTriggerEnter(Collider col){
		if (col.transform.gameObject.tag == "player") {
			audio.PlayOneShot(waterSplash);
			Instantiate(waterEffect, transform.position, transform.rotation);
			Debug.Log("Water Splash");
		}
	}

	void OnTriggerStay(Collider col){
		if (col.transform.gameObject.tag == "player" && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))) {
			audio.PlayOneShot(waterWalk);
			Instantiate(waterEffect, transform.position, transform.rotation);
			Debug.Log("Water Walk");
		}
	}

	void OnTriggerExit(Collider col){
		if (col.transform.gameObject.tag == "player") {
			audio.Stop();
		}
	}
}
