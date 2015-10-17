/*
 * Team Name: Team Buzzinga!
 * Script Created by: Siddharth
 * Other Members: Ryan, Dingfeng, Aaron, David
 */
using UnityEngine;
using System.Collections;

public class PushObject : MonoBehaviour {

	public float pushPower = 0.02f;

	private Rigidbody objectHit;

	void onCollisionEnter(Collision collision){
		objectHit = collision.rigidbody;
		if (objectHit == null || objectHit.isKinematic || objectHit.transform.gameObject.tag != "Pushable")
			return;
		if (collision.transform.position.y < -0.3)
			return;

		Vector3 pushDir = new Vector3 (collision.transform.position.x, 0, collision.transform.position.y);
		objectHit.velocity = pushDir * pushPower; 
	}

}
