using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	//public float maxforce;
	public float moveVelocity;
	//public float rotateSpeed;

	public Transform football;
	public Vector3 direction;

	private bool attachFootball =false;
	private Animator anim;
	private Rigidbody rb;
	private CharacterController cc;
	private NavMeshAgent nma;


	// Use this for initialization
	void Start () {

		anim=GetComponent<Animator>();
		rb=GetComponent<Rigidbody>();
		cc=GetComponent<CharacterController>();
		nma=GetComponent<NavMeshAgent>();

	}	
	
	// Update is called once per frame
	void Update () {

#if Unity_Editor
		//keyboard move
		float h=Input.GetAxis("Horizontal");
		float v=Input.GetAxis("Vertical");

		Vector3 move;

		//move =h*Vector3.forward+v*Vector3.right;
		move=new Vector3(-v,0f,h);
		move=move.normalized*3f*Time.deltaTime;


		//rb.MovePosition(transform.position+move);
		transform.position+=move;
		//end key board move
#endif





		cc.Move (direction*moveVelocity*Time.deltaTime);

	}
	
	#region Touch
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

			float h=swipe.normalized.x;
			float v=swipe.normalized.y;

			//move direction
			direction=new Vector3(-v,0f,h).normalized;

			// rotate
			float angle=Mathf.Acos(h/Mathf.Sqrt(h*h+v*v));

			float a=angle/Mathf.PI*180f;
			if(v>0f){
				a=-a;
			}
			Rotate(a); 




		}
	}
	#endregion

	public void Rotate(float angle){
		Debug.Log(angle);
		
		
		Quaternion newRotation=Quaternion.Euler(new Vector3(transform.localRotation.x,
		                                                    angle,
		                                                    transform.localRotation.z));

		transform.localRotation=newRotation;

	}

//
//	void OnCollisionEnter(Collision collision) {
//
//
//
//		if (collision.gameObject.CompareTag("Football")){
//	
//			attachFootball=true;
//		}
//
//		if (collision.gameObject.CompareTag("Enermy")){
//
//			attachFootball=false;
//		}
//
//	}

}

