using UnityEngine;
using System.Collections;

public class FinishController : MonoBehaviour {

	GameObject flag;

	// Use this for initialization
	void Start () {
	
		flag = GameObject.Find("Flag");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider obj)
	{
		
		if(obj.gameObject.tag == "Player")
		{
			Vector3 pos = flag.transform.position;
			pos.y = 5f;
			flag.transform.position = pos;
		}
		
	}
}
