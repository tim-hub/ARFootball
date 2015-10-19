using UnityEngine;
using System.Collections;

public class FootballShootTouch : MonoBehaviour {

	public Camera cam;
	public float force=200;


	private bool alreadyShoot=false;
	private Vector3 start;
	private Vector3 end;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb=GetComponent<Rigidbody>();

		if(cam==null){

			cam=GameObject.Find("Camera").GetComponent<Camera>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if((!alreadyShoot)&&Input.touchCount>=1){
			Debug.Log("Touched");

			Touch touch=Input.touches[0];

			TouchPhase tp=touch.phase;

			if(tp==TouchPhase.Began){
				start=screenToWorld(touch.position);

			}

			if (tp==TouchPhase.Ended){

				end=screenToWorld(touch.position);

				rb.AddForce((end-start)*force);
				alreadyShoot=true;
				Invoke("TestGoal",3f);

			}



		}
	}
	void TestGoal(){

		if(gameObject!=null){
			Destroy(gameObject);
			GameManager.instance.InstantiateBall();
		}

	}


	Vector3 screenToWorld(Vector2 pos){
		Vector3 viewPos=Camera.main.ScreenToViewportPoint(pos);
		
		Vector3 worldPos =cam.ViewportToWorldPoint
			(new Vector3(viewPos.x,viewPos.y,Mathf.Abs(cam.transform.position.z)));
		return worldPos;
	}
}
