using UnityEngine;
using System.Collections;

public class ScreenShotNow : MonoBehaviour {
	string format;
	
	// Use this for initialization
	void Start () {
		format = "yyyy-MM-dd-HH-mm-ss"; 
	}


	// Update is called once per frame
	void Update () {

		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.Space)){
			ScreenShotButton();
		}
		#endif

		if(Input.touchCount>=2){

			ScreenShotButton();
		}
	}


	public void ScreenShotButton(){

		Application.CaptureScreenshot(Application.dataPath + "/" + System.DateTime.Now.ToString(format) +".png");
	}
}
