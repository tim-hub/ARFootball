using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIFriendMove : MonoBehaviour {


	public Transform dl0;
	public Transform dm1;
	public Transform dr2;
	public Transform ml3;
	public Transform mm4;
	public Transform mr5;
	public Transform ul6;
	public Transform ur8;
	public Transform um7;


	public Transform gate;
	public Transform ball;

	public float distance=3f;


	private Vector3 target;

	private List<Transform> points=new List<Transform>();
	private Animator anim;
	private Rigidbody rb;
	private CharacterController cc;
	private NavMeshAgent nma;


	private bool ballIn=false;
	private bool ballGet=false;
	private bool gateIn=false;
	private bool arrival=false;



	// Use this for initialization
	void Start () {
		dl0=GameObject.Find("dl0").transform;
		dm1=GameObject.Find("dm1").transform;
		dr2=GameObject.Find("dr2").transform;
		ml3=GameObject.Find("ml3").transform;
		mm4=GameObject.Find("mm4").transform;
		mr5=GameObject.Find("mr5").transform;
		ul6=GameObject.Find("ul6").transform;
		um7=GameObject.Find("um7").transform;
		ur8=GameObject.Find("ur8").transform;



		points.Add(dl0);
		points.Add(dm1);
		points.Add(dr2);
		points.Add(ml3);
		points.Add(mm4);
		points.Add(mr5);
		points.Add(ul6);
		points.Add(um7);
		points.Add(ur8);

		cc=GetComponent<CharacterController>();
		nma=GetComponent<NavMeshAgent>();

		target=mr5.position;

	}
	
	// Update is called once per frame
	void Update () {


		if(ballIn && gateIn){
			//shoot
			Shoot();
			ballIn=false;
			gateIn=false;

		}else if(ballIn ){
			//go to ball
			nma.SetDestination(ball.position);

			//nma.SetDestination(gate.position);

		}else if(ballGet){
			nma.SetDestination(gate.position);

		}else{
			nma.SetDestination(target);
		}


		if((ball.position-transform.position).magnitude<=distance){

			ballIn=true;
		}

		if(ballIn&&transform.position.z<ball.transform.position.z && ball.transform.position.z<gate.transform.position.z){

			ballGet=true;
		}

		if(((gate.position-transform.position).magnitude<=distance)){

			gateIn=true;
		}

		if(transform.position.z==target.z){
			arrival=true;
			target=GetRandomPos();
		}

	}

	void Shoot(){
		Debug.Log("AI Shoot");


	}

	Vector3 GetRandomPos(){

		return points[Random.Range(0,points.Count)].position;


	}

	void MoveTo(Vector3 pos){

		nma.SetDestination(pos);

	}
}
