using UnityEngine;
using System.Collections;

public class FinishController : MonoBehaviour {

	GameObject flag;

	GameObject player;

	// Use this for initialization
	void Start () {
	
		flag = GameObject.Find("Flag");
		player = GameObject.FindGameObjectWithTag("Player");
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
			Animator anim = player.GetComponent<Animator>();

			anim.SetBool("Win",true);

		}
		
	}
}
