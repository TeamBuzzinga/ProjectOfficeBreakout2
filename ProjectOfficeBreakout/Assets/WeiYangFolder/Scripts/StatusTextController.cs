using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusTextController : MonoBehaviour {

	string status;
	Text text;

	Animator anim;

	// Use this for initialization
	void Awake () {
		text = GetComponent <Text> ();

		anim = GameObject.Find("Player").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetBool("Lose") == true)
		{
			setText("You Lose! Press 'R' to Restart");
		}
		else if(anim.GetBool("Win") == true)
		{
			setText("Congrats! You Win. Press 'R' to Replay!");
	
		}
		else
			setText("");
	}

	public void setText(string s)
	{
		text.text=s;
	}
}
