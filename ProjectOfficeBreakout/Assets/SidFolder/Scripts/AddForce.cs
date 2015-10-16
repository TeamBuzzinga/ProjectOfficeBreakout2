using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public float force = 1000f;
	private Rigidbody rigidBody;
	public Transform transform;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}

	void OnMouseDown(){
		rigidBody.AddForce (-transform.right * force);
		rigidBody.useGravity = true;
	}
}
