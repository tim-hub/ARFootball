using UnityEngine;
using System.Collections;

public class CameraFollowThePlayer : MonoBehaviour {

	public GameObject player;
	public bool follow=true;

	
	private Vector3 distance;

	void Start () {

		distance=player.transform.position-gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(follow){
			gameObject.transform.position=player.transform.position-distance;
		}
	}
}
