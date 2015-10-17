using UnityEngine;
using System.Collections;

public class LoseController : MonoBehaviour {

	GameObject player;
	
	// Use this for initialization
	void Start () {
		
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider obj)
	{
		
		if(obj.gameObject.tag == "Player")
		{
			Animator anim = player.GetComponent<Animator>();
			
			anim.SetBool("Lose",true);
			
		}
		
	}
}
