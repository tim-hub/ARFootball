using UnityEngine;
using System.Collections;

public class GoalOnAwake : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GetComponent<AudioSource>().Play();
	}

}
