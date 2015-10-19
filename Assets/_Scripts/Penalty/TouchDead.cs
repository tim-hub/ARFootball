using UnityEngine;
using System.Collections;

public class TouchDead : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Football")){
			Destroy(col.gameObject);
			Invoke("NewBall",0.6f);
		}

	}

	void NewBall(){

		GameManager.instance.InstantiateBall();
	}
}
