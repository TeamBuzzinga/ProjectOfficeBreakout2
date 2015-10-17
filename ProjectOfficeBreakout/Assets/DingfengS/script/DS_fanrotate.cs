/*
Team Buzzinga

Author: Dingfeng Shao

Member: Aaron Quek; David Chang; Ryan Anderson;	Siddharth
*/
using UnityEngine;
using System.Collections;

public class DS_fanrotate : MonoBehaviour {

	public int turnspeed=4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * turnspeed);
	}
}
