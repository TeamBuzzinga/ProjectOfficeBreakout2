/*
Team Buzzinga

Author: Dingfeng Shao

Member: Aaron Quek; David Chang; Ryan Anderson;	Siddharth
*/
using UnityEngine;
using System.Collections;

public class DS_opendoor : MonoBehaviour {
	float smooth=2.0f;
	float dooropenangle=90.0f;
	bool open,enter;
	Vector3 defaultRot;
	Vector3 openRot;

	// Use this for initialization
	void Start () {
		defaultRot = transform.eulerAngles;
		openRot = new Vector3 (defaultRot.x, defaultRot.y + dooropenangle, defaultRot.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (open)
			transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, openRot, Time.deltaTime*smooth);
		else
			transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, defaultRot, Time.deltaTime*smooth);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			open = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
			open = false;
	}
}
