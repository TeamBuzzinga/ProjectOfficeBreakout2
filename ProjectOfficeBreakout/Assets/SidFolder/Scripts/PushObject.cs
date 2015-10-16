using UnityEngine;
using System.Collections;

public class PushObject : MonoBehaviour {

	public float pushPower = 2.0f;

	private Rigidbody objectHit;

	void onCollisionEnter(Collision collision){
		objectHit = collision.rigidbody;
		if (objectHit == null || objectHit.isKinematic)
			return;
		if (collision.transform.position.y < -0.3)
			return;

		Vector3 pushDir = new Vector3 (collision.transform.position.x, 0, collision.transform.position.y);
		objectHit.velocity = pushDir * pushPower;
	}

}
