using UnityEngine;
using System.Collections;

public class AnimTrigger : MonoBehaviour {

	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent <Animator> ();
	}
		
	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "JumpTrigger") {
			animator.SetBool ("Jump", true);
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.name == "JumpTrigger") {
			animator.SetBool ("Jump", false);
		}
	}
}
