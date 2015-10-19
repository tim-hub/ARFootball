using UnityEngine;
using System.Collections;

public class TargetInvoke : MonoBehaviour {


	public GameObject onit;
	// Use this for initialization
	void Start () {
		Invoke("ActiveIt",0.2f);
	}
	
	// Update is called once per frame
	void ActiveIt(){
		onit.SetActive(true);

	}
}
