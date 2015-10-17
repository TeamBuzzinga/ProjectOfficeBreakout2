/*
Team Buzzinga

Member: Aaron Quek; David Chang; Dingfeng Shao; Ryan Anderson;	Siddharth
*/
using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class DS_PlayerController : MonoBehaviour
{
	[System.NonSerialized]					
	public float lookWeight;					// the amount to transition when using head look
	
	[System.NonSerialized]
	public Transform enemy;						// a transform to Lerp the camera to during head look
	
	public float animSpeed = 1.5f;				// a public setting for overall animator animation speed
	public float lookSmoother = 3f;				// a smoothing setting for camera motion
	public bool useCurves;						// a setting for teaching purposes to show use of curves

	
	private Animator anim;							// a reference to the animator on the character
	private AnimatorStateInfo currentBaseState;			// a reference to the current state of the animator, used for base layer
	private AnimatorStateInfo layer2CurrentState;	// a reference to the current state of the animator, used for layer 2
	private CapsuleCollider col;					// a reference to the capsule collider of the character

	public Transform player_pos;

	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");			// these integers are references to our animator's states
	static int jumpState = Animator.StringToHash("Base Layer.Jump");				// and are used to check state for various actions to occur
	static int crouchState = Animator.StringToHash("Base Layer.Crouch");
	static int crouchWalkState = Animator.StringToHash("Base Layer.CrouchWalk");

	GameObject pick;
	Color origin=Color.clear;
	AudioSource _walk;
	AudioSource _jump;
	Light _light;
	Rigidbody[] rigids;
	DS_CameraController cam1;

	void Start ()
	{
		anim = GetComponent<Animator>();
		cam1 = GetComponent<DS_CameraController> ();
		col = GetComponent<CapsuleCollider>();	
		_light = GetComponentInChildren<Light> ();
		rigids=GetComponentsInChildren<Rigidbody>();
		_light.enabled = false;
		AudioSource[] audios=GetComponents<AudioSource> ();
		_walk = audios [0];
		_jump = audios [1];
		if(anim.layerCount ==2)
			anim.SetLayerWeight(1, 1);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("pickup")) {
				pick=other.gameObject;
				origin=other.gameObject.GetComponent<Renderer>().material.color;
				other.gameObject.GetComponent<Renderer>().material.color=Color.green;
				print ("collide"+pick.tag);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag ("box")) 
		{
			foreach(ContactPoint contact in other.contacts)
			{
				contact.thisCollider.GetComponent<Animator>().enabled=false;
				contact.thisCollider.attachedRigidbody.AddForce(contact.normal*3,ForceMode.Impulse);
				cam1.enabled=false;
			}
		}

	}

	/*
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("pickup")) {
			pick=null;
			other.gameObject.GetComponent<Renderer>().material.color=origin;
		}
	}
*/

	void jumpAudio()
	{
		_walk.Stop ();
		if(!_jump.isPlaying&&anim.enabled)
			_jump.Play ();
	}

	void pick_up()
	{
		if(pick!=null)
		{
			pick.SetActive(false);
			_light.enabled=true;
			pick=null;
		}
	}

	void FixedUpdate ()
	{

		if (Input.GetKeyDown(KeyCode.R)) {
			anim.enabled=true;
			anim.SetTrigger("getup");
			cam1.enabled=true;
		}

		float h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		float v = Input.GetAxis("Vertical");				// setup v variables as our vertical input axis
		anim.SetFloat("Speed", v);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.SetFloat("Direction", h); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis		


		anim.speed = animSpeed;								// set the speed of our animator to the public variable 'animSpeed'
		anim.SetLookAtWeight(lookWeight);					// set the Look At Weight - amount to use look at IK vs using the head's animation
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation
		
		if(anim.layerCount ==2)		
			layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);	// set our layer2CurrentState variable to the current state of the second Layer (1) of animation

		
		if (Input.GetKeyDown (KeyCode.P)) {
			anim.SetTrigger("picking");
		}

		if (v != 0.0) {
			if(!_walk.isPlaying&&currentBaseState.nameHash != jumpState&&anim.enabled)
				_walk.Play ();
		}
		else
			_walk.Stop ();

		if (currentBaseState.nameHash == locoState) {
			if (Input.GetKey(KeyCode.C)) {
				anim.SetBool ("Crouch", true);
			}

			if(!(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
			{
				float s = anim.GetFloat("Speed");
				anim.SetFloat("Speed",s/4);
			}
		}
		else if (currentBaseState.nameHash == crouchState) {
			if (Input.GetKey(KeyCode.C)) {
				anim.SetBool ("Crouch", false);
			}
		}
		
		else if (currentBaseState.nameHash == crouchWalkState) {
			if (Input.GetKey(KeyCode.C)) {
				anim.SetBool ("Crouch", false);
			}
		}
		
		// STANDARD JUMPING
		
		// if we are currently in a state called Locomotion (see line 25), then allow Jump input (Space) to set the Jump bool parameter in the Animator to true
		if (currentBaseState.nameHash == locoState)
		{
			if(Input.GetButtonDown("Jump"))
			{
				anim.SetBool("Jump", true);
				_walk.Stop();
			}
		}
		
		// if we are in the jumping state... 
		else if(currentBaseState.nameHash == jumpState)
		{
			_walk.Stop();
			//  ..and not still in transition..
			if(!anim.IsInTransition(0))
			{
				if(useCurves)
					// ..set the collider height to a float curve in the clip called ColliderHeight
					col.height = anim.GetFloat("ColliderHeight");
				
				// reset the Jump bool so we can jump again, and so that the state does not loop 
				anim.SetBool("Jump", false);

			}
			
			// Raycast down from the center of the character.. 
			Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
			RaycastHit hitInfo = new RaycastHit();
			
			if (Physics.Raycast(ray, out hitInfo))
			{
				// ..if distance to the ground is more than 1.75, use Match Target
				if (hitInfo.distance > 1.75f)
				{
					anim.MatchTarget(hitInfo.point, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask(new Vector3(0, 1, 0), 0), 0.35f, 0.5f);
				}

			}

		}
	}
}
