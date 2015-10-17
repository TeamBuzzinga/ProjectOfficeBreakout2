using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class AaronController : MonoBehaviour
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

//	private CharacterController charCon;

	static int idleState = Animator.StringToHash("Base Layer.Idle");	
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");			// these integers are references to our animator's states
	static int jumpState = Animator.StringToHash("Base Layer.Jump");				// and are used to check state for various actions to occur
	static int crouchState = Animator.StringToHash("Base Layer.Crouch");
	static int crouchWalkState = Animator.StringToHash("Base Layer.CrouchWalk");

	static int loseState = Animator.StringToHash("Base Layer.Lose");
	static int winState = Animator.StringToHash("Base Layer.Win");

	static int grabState = Animator.StringToHash("Layer 2.Grab");

	public float slipperyFriction = 0.99999999999999f;
	public float slipperySpeed = 0.08f;
	Rigidbody rb;

	Vector3 rbAngle;
	Vector3 rbPos;
	float rbTransX;
	float rbTransZ;
	public float gravity = 0.0001f;
	float downSpeed = 0f;

	float slipX = 0f;
	float slipZ = 0f;

	bool grabbing = false;
	GameObject o;

	int cp = 0;
	public Transform cube;

	void Start ()
	{
		anim = GetComponent<Animator>();					  
		col = GetComponent<CapsuleCollider>();	
		
		if(anim.layerCount ==2)
			anim.SetLayerWeight(1, 1);

		anim.SetBool("Lose",false);
		anim.SetBool("Win",false);

		Vector3 startPos = new Vector3(20f,25.6f,17f);
		transform.position = startPos;
	}
	
	
	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		float v = Input.GetAxis("Vertical");				// setup v variables as our vertical input axis
		anim.SetFloat("Speed", v);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.SetFloat("Direction", h); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis		
		anim.speed = animSpeed;								// set the speed of our animator to the public variable 'animSpeed'
		anim.SetLookAtWeight(lookWeight);					// set the Look At Weight - amount to use look at IK vs using the head's animation
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation
		
		if(anim.layerCount ==2)		
			layer2CurrentState = anim.GetCurrentAnimatorStateInfo(1);	// set our layer2CurrentState variable to the current state of the second Layer (1) of animation


		//gravity
		// Use Raycast to prevent character floating bug
		Ray gravityRay = new Ray(transform.position + Vector3.up, -Vector3.up);
		RaycastHit gravityHitInfo = new RaycastHit();

		Debug.DrawRay(transform.position + Vector3.up, -Vector3.up);

		if (Physics.Raycast(gravityRay, out gravityHitInfo))
		{
			if (gravityHitInfo.distance > 1.2f)
			{
				downSpeed =0.3f;
				transform.position = new Vector3(transform.position.x,transform.position.y-downSpeed, transform.position.z);
			}
			else
				downSpeed = 0f;
		}

		//Press 'R' to restart
		if (Input.GetKeyDown (KeyCode.R)) {  
			Application.LoadLevel ("WeiYangDemoScene");  
		}  

	
		Vector3 currentPos = transform.position;

		Ray onIceRay = new Ray(transform.position + Vector3.up, -Vector3.up);
		RaycastHit onIceHitInfo = new RaycastHit();

		if(Physics.Raycast(onIceRay, out onIceHitInfo))
		{

			if(onIceHitInfo.collider.tag == "Ice" && onIceHitInfo.distance < 1.75f)
			{
				rb = GetComponent<Rigidbody>();
				rbAngle = transform.rotation.eulerAngles;
				rbPos = rb.transform.position;


				if(rbAngle.y>= 0f && rbAngle.y <90f)
				{
					rbTransX = 0.1f*Input.GetAxis("Vertical")*Mathf.Sin(rbAngle.y * Mathf.Deg2Rad);
					rbTransZ = 0.1f*Input.GetAxis("Vertical")*Mathf.Cos(rbAngle.y * Mathf.Deg2Rad);
				}
				else if(rbAngle.y >=90f && rbAngle.y <180f)
				{
					rbTransX = 0.1f*Input.GetAxis("Vertical")*Mathf.Sin(rbAngle.y * Mathf.Deg2Rad);
					rbTransZ = 0.1f*Input.GetAxis("Vertical")*Mathf.Cos(rbAngle.y * Mathf.Deg2Rad);
				}
				else if (rbAngle.y >= 180f && rbAngle.y<270f)
				{
					rbTransX = 0.1f*Input.GetAxis("Vertical")*Mathf.Sin(rbAngle.y * Mathf.Deg2Rad);
					rbTransZ = 0.1f*Input.GetAxis("Vertical")*Mathf.Cos(rbAngle.y * Mathf.Deg2Rad);
				}
				else
				{
					rbTransX = 0.1f*Input.GetAxis("Vertical")*Mathf.Sin(rbAngle.y * Mathf.Deg2Rad);
					rbTransZ = 0.1f*Input.GetAxis("Vertical")*Mathf.Cos(rbAngle.y * Mathf.Deg2Rad);
				}


				if (Input.GetAxis("Vertical") != 0f )
				{

					slipX += slipperySpeed * rbTransX;
					slipZ += slipperySpeed * rbTransZ;
				}
				else
				{
					slipX *= slipperyFriction;
					slipZ *= slipperyFriction;
				}

				transform.position =  new Vector3(currentPos.x + slipX, currentPos.y, currentPos.z + slipZ);

			}
			else
			{
				slipX =0f;
				slipZ = 0f;
			}
		

		}
		if (currentBaseState.nameHash == locoState)
		{
			if(Input.GetButtonDown("Jump"))
			{
				anim.SetBool("Jump", true);
			}
			
			if (Input.GetKey(KeyCode.C)) {
				anim.SetBool ("Crouch", true);
			}
			
			if(!(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
			{
				float s = anim.GetFloat("Speed");
				anim.SetFloat("Speed",s/4);
			}
		}

		//Use Grab when player click left mouse button
		if(Input.GetButtonDown("Fire1"))
			anim.SetBool("Grab",true);

		//Rotate Through different checkpoints

		if(Input.GetButtonDown("Fire2"))
			rotatePosition();


		if (currentBaseState.nameHash == crouchState) {
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

		// if we are in the jumping state... 
		else if(currentBaseState.nameHash == jumpState)
		{
			//  ..and not still in transition..
			if(!anim.IsInTransition(0))
			{
				if(useCurves)
					// ..set the collider height to a float curve in the clip called ColliderHeight
					col.height = anim.GetFloat("ColliderHeight");
				
				// reset the Jump bool so we can jump again, and so that the state does not loop 
				anim.SetBool("Jump", false);
			}

		}

		if(layer2CurrentState.nameHash == grabState)
		{
			if(!Input.GetButton("Fire1") || Input.GetButtonUp("Fire1"))
			{
				anim.SetBool("Grab",false);
				grabbing = false;
			}

			//check what object is diagonally in front of the player
			Ray grabRay = new Ray(transform.position+Vector3.up,transform.forward + Vector3.down);
			RaycastHit grabHit = new RaycastHit();
			//				ePos = hitInfo.distance;
			if (Physics.Raycast(grabRay, out grabHit,1))
			{
				if(grabHit.collider.tag=="CrashCubes")
				{
					o = grabHit.collider.gameObject;
					o.transform.position = transform.position + transform.forward +transform.up;
					grabbing = true;
				}
			}

		}

		//hold object in front of player when he is grabbing it
		if(grabbing ==true)
		{
			o.transform.position = transform.position + transform.forward + transform.up;
			o.GetComponent<Rigidbody>().useGravity = false;
		}
		else
		{
			o.GetComponent<Rigidbody>().useGravity = true;
		}


		
	}

	void rotatePosition()
	{
		cp++;
		cp = cp%4;

		Vector3 newPos = new Vector3(20f,25.6f,17f);
		switch(cp)
		{
		case 0:
			newPos = new Vector3(20f,25.6f,17f);
			break;
		case 1:
			newPos = new Vector3(-7.8f,21f,14f);
			break;
		case 2:
			newPos = new Vector3(-7.8f,17f,2.2f);
			Instantiate(cube, new Vector3(-8.3f,17.73f,-3.81f),Quaternion.identity);
			break;
		case 3:
			newPos = new Vector3(14f,17f,-3f);
			break;
		}
		transform.position = newPos;


	}
}
