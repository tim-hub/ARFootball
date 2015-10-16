using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float maxforce;
	public float maxVelocity;
	public float rotateSpeed;

	private Animator anim;
	private Rigidbody rb;






	// Use this for initialization
	void Start () {

		anim=GetComponent<Animator>();
		rb=GetComponent<Rigidbody>();


	}	
	
	// Update is called once per frame
	void FixedUpdate () {

#if Unity_Editor
		//keyboard move
		float h=Input.GetAxis("Horizontal");
		float v=Input.GetAxis("Vertical");

		Vector3 move;

		//move =h*Vector3.forward+v*Vector3.right;
		move=new Vector3(-v,0f,h);
		move=move.normalized*3f*Time.deltaTime;


		rb.MovePosition(transform.position+move);
		//end key board move
#endif





	}


	protected virtual void OnEnable()
	{
		// Hook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe += OnFingerSwipe;
	}
	
	protected virtual void OnDisable()
	{
		// Unhook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe -= OnFingerSwipe;
	}
	
	public void OnFingerSwipe(Lean.LeanFinger finger)
	{
		// Make sure the info text exists
		if (gameObject != null)
		{
			// Store the swipe delta in a temp variable
			var swipe = finger.SwipeDelta;

			Debug.Log(swipe);
//			if (swipe.x < -Mathf.Abs(swipe.y))
//			{
//
//				
//			}
//			
//			if (swipe.x > Mathf.Abs(swipe.y))
//			{
//
//			}
//			
//			if (swipe.y < -Mathf.Abs(swipe.x))
//			{
//
//			}
//			
//			if (swipe.y > Mathf.Abs(swipe.x))
//			{
//
//			}
			float h=swipe.normalized.x;
			float v=swipe.normalized.y;

			// add force to move
			rb.AddForce(-v*maxforce,0,h*maxforce);



			float angle=Mathf.Acos(h/Mathf.Sqrt(h*h+v*v));

			float a=angle/Mathf.PI*180f;
			if(v>0f){
				a=-a;
			}
			Rotate(a); 



			//restrict the velocity, it seems that it does not work
			Vector3 velocity=rb.velocity;
			if(velocity.magnitude>maxVelocity){
				float x= maxVelocity*(velocity.x/(Mathf.Sqrt(velocity.x*velocity.x+
				                                             velocity.y*velocity.y)));
				float z= maxVelocity*(velocity.z/(Mathf.Sqrt(velocity.x*velocity.x+
				                                             velocity.y*velocity.y)));
				
				rb.velocity=new Vector3(x,0,z);
			}
		}
	}

	public void Rotate(float angle){
		Debug.Log(angle);
		
		
		Quaternion newRotation=Quaternion.Euler(new Vector3(transform.localRotation.x,
		                                                    angle,
		                                                    transform.localRotation.z));
		
		
		transform.localRotation=newRotation;

	}


	public void OnFingerTap(Lean.LeanFinger finger){



	}
}

