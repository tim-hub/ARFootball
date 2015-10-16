using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float force=200f;
	public float maxVelocity=2f;
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

		if(rb.velocity!=Vector3.zero){
			Debug.Log(rb.velocity);
		}



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
			float h=swipe.x/100f;
			float v=swipe.y/100f;




			rb.AddForce(-v*force,0,h*force);

//			if(swipe.x<0f){
//				Debug.Log("Move back");
//				rb.AddForce(0,0,-force));
//				//rb.MovePosition(transform.position+new Vector3(0f,0f,-5f));
//
//			}
//			if(swipe.x>0f){
//				Debug.Log("Move back");
//				rb.AddForce(0,0,force);
//				//rb.MovePosition(transform.position+new Vector3(0f,0f,-5f));
//				
//			}
//			if(swipe.x>0f){
//				Debug.Log("Move forward");
//				rb.AddForce(0,0,200);
//			}
//
//			if(swipe.y<0f){
//				rb.AddForce(200,0,0);
//			}
//			if(swipe.y>0f){
//
//				rb.AddForce(-200,0,0);
//			}
		}
	}
}

