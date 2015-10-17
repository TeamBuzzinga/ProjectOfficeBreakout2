/*
Team Buzzinga

Author: Dingfeng Shao

Member: Aaron Quek; David Chang; Ryan Anderson;	Siddharth
*/
using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour {
	Animator anim;
	GameObject pick;
	Color origin=Color.clear;
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	void FixedUpdate () {
		//move
		float h = Input.GetAxisRaw("Horizontal");			
		float v = Input.GetAxisRaw("Vertical");
		anim.SetFloat("move", v);									
		anim.SetFloat("direction", h);
		//jumping
		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetTrigger("jumping");
		}
		//picking
		if (Input.GetKeyDown (KeyCode.P)) {
			anim.SetTrigger("picking");
			if(pick!=null)
			{
				pick.SetActive(false);
				pick=null;
			}
		}
		//pushing
		if (Input.GetKeyDown (KeyCode.H)) {
			anim.SetTrigger("pushing");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("pickup")) {
			pick=other.gameObject;
			origin=other.gameObject.GetComponent<Renderer>().material.color;
			other.gameObject.GetComponent<Renderer>().material.color=Color.green;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("pickup")) {
			pick=null;
			other.gameObject.GetComponent<Renderer>().material.color=origin;
		}
	}



}
