using UnityEngine;
using System.Collections;

public class CameraFollowThePlayer : MonoBehaviour {

	public GameObject player;
	public float smooth=3f;   //smooth is bigger, the gollow is more quick, 0 : no follow
	
	private Vector3 distance;
	// Use this for initialization
	void Start(){
		distance=transform.position-player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos=player.transform.position+distance;
		
		transform.position=Vector3.Lerp(transform.position,pos,smooth*Time.deltaTime);
	}
}
