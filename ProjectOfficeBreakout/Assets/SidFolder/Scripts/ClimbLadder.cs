using UnityEngine;
using System.Collections;

public class ClimbLadder : MonoBehaviour {

	public Transform ChController;
	public float heightFactor = 3;
	public bool inside = false;

//	void Start() {
//		ChController = GetComponent<Transform> ();
//	}

	// Update is called once per frame
	void Update () {
		if(inside == true && Input.GetKey("w")) {
		   ChController.transform.position += Vector3.up / heightFactor;
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Ladder") {
			inside = !inside;
		}
	}

	
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Ladder") {
			inside = !inside;
		}
	}

}
