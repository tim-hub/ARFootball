using UnityEngine;
using System.Collections;

public class AdBoard : MonoBehaviour {


	public float bounce=5f;
	void OnCollisionEnter(Collision collision) {
		// Debug-draw all contact points and normals
		
		//Debug.Log("Ball touch ad board" +collision.contacts[0].point);
		//		foreach (ContactPoint contact in collision.contacts) {
		//			Debug.DrawRay(contact.point, contact.normal, Color.white);
		//
		//
		//		}
		
		if(collision.gameObject.CompareTag("Football")){  //collision.contacts[0].point
			Debug.Log("Ball touch ad board" +collision.contacts[0].point);
			collision.gameObject.GetComponent<Rigidbody>().AddForce(bounce*(collision.transform.position-collision.contacts[0].point));
		}
		
		
		Debug.Log(collision.transform.position-collision.contacts[0].point);




	}
}
