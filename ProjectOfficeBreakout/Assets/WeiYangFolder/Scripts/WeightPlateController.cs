using UnityEngine;
using System.Collections;

public class WeightPlateController : MonoBehaviour {

	GameObject platform;

	// Use this for initialization
	void Start () {
		platform = GameObject.Find("MovingPlatform");

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider obj)
	{
		Vector3 pos = platform.transform.position;
		Vector3 scale = platform.transform.localScale;

		if(obj.gameObject.tag == "CrashCubes")
		{
			pos.x = -2f;
			scale.x = 11f;
			platform.transform.position = pos;
			platform.transform.localScale = scale;
		}

	}

	void OnTriggerExit(Collider obj)
	{
		Vector3 pos = platform.transform.position;
		Vector3 scale = platform.transform.localScale;

		if(obj.gameObject.tag == "CrashCubes")
		{
			pos.x = -7f;
			scale.x = 1f;
			platform.transform.position = pos;
			platform.transform.localScale = scale;
		}
	}
}
