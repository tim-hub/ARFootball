using UnityEngine;
using System.Collections;

public class ScreenShotNow : MonoBehaviour {
	string format;
	
	// Use this for initialization
	void Start () {
		format = "yyyy-MM-dd-HH-mm-ss"; 
	}

#if UNITY_EDITOR
	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.Space)){
			Application.CaptureScreenshot(Application.dataPath + "/" + System.DateTime.Now.ToString(format) +".png");
		}
	}

#endif
	public void ScreenShotButton(){

		Application.CaptureScreenshot(Application.dataPath + "/" + System.DateTime.Now.ToString(format) +".png");
	}
}
