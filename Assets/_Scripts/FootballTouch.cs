using UnityEngine;
using System.Collections;

public class FootballTouch : MonoBehaviour {
	public float force=1.5f;

	public float borderZ=6.8f;
	public float borderX=4.8f;



//	void OnCollisionEnter(Collider other){
//
//		Debug.Log("Player Touch Ball");
//
//		if (other.gameObject.CompareTag("Player")){
//
//			GetComponent<Rigidbody>().AddForce((transform.position-other.transform.position));
//		}
//
//
//	}
	void OnTriggerEnter(Collider other) {
		// Debug-draw all contact points and normals


//		foreach (ContactPoint contact in collision.contacts) {
//			Debug.DrawRay(contact.point, contact.normal, Color.white);
//
//
//		}

		if(other.gameObject.CompareTag("Player")){
			Debug.Log("Player Touch Ball");
			GetComponent<Rigidbody>().AddForce((transform.position-other.transform.position)*force);
		}
		

		
	}

	/// <summary>
	/// update
	/// clamp the football position
	/// </summary>
//	void Update(){
//		Vector3 pos =transform.position;
//		float x= Mathf.Clamp(pos.x,-borderX,borderX);
//		float z=Mathf.Clamp(pos.z,-borderZ,borderZ);
//
//		transform.position=new Vector3(x,transform.position.y,z);
//
//	}

}
