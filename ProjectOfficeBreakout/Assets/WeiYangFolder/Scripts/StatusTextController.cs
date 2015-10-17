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
			setText("You Lose! Press '2' to Restart");
		}
		else if(anim.GetBool("Win") == true)
		{
			setText("Congrats! You Win. Press '2' to Replay or press one of the other numbers 1-5 to explore other levels!");
	
		}
		else
			setText("");
	}

	public void setText(string s)
	{
		text.text=s;
	}
}
