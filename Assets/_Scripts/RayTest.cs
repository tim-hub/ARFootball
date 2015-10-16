using UnityEngine;
using System.Collections;

public class RayTest : MonoBehaviour {
	public Camera cam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>=1){
			Debug.Log("touch");


			Ray ray=cam.ScreenPointToRay(Input.touches[0].position);
			RaycastHit hit;

			if(Physics.Raycast(ray,out hit)){
				transform.position=hit.point;


			}




		}


	}
}
