using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	public GameObject goalText;


	void OnTriggerEnter(Collider col){
		if(col.gameObject.CompareTag("Football") ){

			GameManager.instance.Goal();


			GameObject goal=Instantiate(goalText,transform.position+new Vector3(0f,1.5f,0f),Quaternion.identity) as GameObject;

			if(GameManager.instance.numball==0){

				Destroy(goal);
			}

			GetComponent<AudioSource>().Play();
			Destroy(goal,3f);

			Invoke("StopAudio",5f);
		}

	}


	void StopAudio(){

		GetComponent<AudioSource>().Stop ();

	}
}
