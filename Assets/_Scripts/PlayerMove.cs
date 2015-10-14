using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {


	private Animator anim;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		anim=GetComponent<Animator>();
		rb=GetComponent<Rigidbody>();


	}	
	
	// Update is called once per frame
	void FixedUpdate () {
		float h=Input.GetAxis("Horizontal");
		float v=Input.GetAxis("Vertical");

		Vector3 move;

		//move =h*Vector3.forward+v*Vector3.right;
		move=new Vector3(-v,0f,h);
		move=move.normalized*3f*Time.deltaTime;


		rb.MovePosition(transform.position+move);




	}
}
