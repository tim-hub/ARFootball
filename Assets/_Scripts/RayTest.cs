using UnityEngine;
using System.Collections;

public class RayTest : MonoBehaviour {
	public Camera cam;
	public LayerMask field;

	
	public Transform football;
	//public Vector3 direction;
	
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

		if(cam==null||cam.isActiveAndEnabled==false ){

			cam=Camera.main;
		}
		
	}	
	
	// Update is called once per frame
	void Update () {


#if UNITY_EDITOR
		if(Input.GetMouseButtonDown(0)){
			//Debug.Log("lift click");
			Ray ray=cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			
			
			if(Physics.Raycast(ray,out hit,1000f, field)){

				Debug.Log(hit.point);
				//cc.SimpleMove(hit.point+new Vector3(0f,transform.position.y,0f));
				nma.SetDestination(hit.point);
				
			}

		}


#endif



		if(Input.touchCount>=1){
			//Debug.Log("touch");


			Ray ray=cam.ScreenPointToRay(Input.touches[0].position);
			RaycastHit hit;



			if(Physics.Raycast(ray,out hit,1000f, field)){

				cc.SimpleMove(hit.point);
				
			}




		}


	}
}
