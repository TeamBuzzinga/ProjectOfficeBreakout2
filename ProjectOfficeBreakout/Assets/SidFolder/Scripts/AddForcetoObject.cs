/*
 * Team Name: Team Buzzinga!
 * Script Created by: Siddharth
 * Other Members: Ryan, Dingfeng, Aaron, David
 */
using UnityEngine;
using System.Collections;

public class AddForcetoObject : MonoBehaviour {

	public float force = 1000f;
	private Rigidbody rigidBody;
	public Transform transform;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent <Rigidbody> ();
//		if(transform.gameObject.name == "Cube_door")
			audio = GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	} 
//
//	void OnMouseDown(){
//		rigidBody.AddForce (-transform.right * force);
//		rigidBody.useGravity = true;
////		if(transform.gameObject.name == "Cube_door")
//			audio.Play ();
//	}
//
	
	public void addForce(){
		rigidBody.AddForce (-transform.right * force);
		rigidBody.useGravity = true;
		//		if(transform.gameObject.name == "Cube_door")
		audio.Play ();
	}
}

