using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance=null;

	//public GameObject goalText;
	public Text scoreText;
	public GameObject tipsText;
	public GameObject football;
	public GameObject bigBall;


	public int goals;


	public int numball=5;

	private string format ; 
	// Use this for initialization
	void Start () {
		Time.timeScale=1f;
		if(instance==null){ //do we have a game manager yet, if no
			instance=this;	//than this is the game manager
		}else if(instance!=this){ //is there is
			Destroy(gameObject); //than destroy this
		}

		format = "yyyy-MM-dd-HH-mm-ss"; 

		Invoke("FirstBall", 0.5f);

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();

		}

		scoreText.text="Score: "+goals;


		// screen shot in the fulture
		if(Input.touchCount==3){
			if(Input.touches[0].phase==TouchPhase.Began &&Input.touches[1].phase==TouchPhase.Began
			   &&Input.touches[2].phase==TouchPhase.Began){
				Application.CaptureScreenshot(Application.persistentDataPath + "/" + System.DateTime.Now.ToString(format) +".png");
				//Application.persistentDataPath  for android
				
			}

		}else if(Input.touchCount==2){
			if(Input.touches[0].phase==TouchPhase.Began &&Input.touches[1].phase==TouchPhase.Began){
				

				Application.LoadLevel(Application.loadedLevel);
			}
		}


		if(numball==0){
			//Time.timeScale=0.1f;

			ShowTips();
		}
	}

	void FirstBall(){
		GameObject ball=Instantiate(football,new Vector3(0f,1f,4.85f),Quaternion.identity) as GameObject;
		ball.transform.parent = this.gameObject.transform;


	}
	public void Goal(){

		goals++;
		//goalText.SetActive(true);
		Time.timeScale=.25f;
		Invoke("HideGoalText",.4f);
	}

	public void HideGoalText(){
		Time.timeScale=1f;


	}

	public void InstantiateBall(){
		Time.timeScale=1f;
		numball--;

		if (numball>=1){

			Instantiate(football,new Vector3(0f,0.7f,4.85f-(float)(5-numball)),Quaternion.identity);
	
		}

	}

	public void ShowTips(){
		tipsText.SetActive(true);
		//remove big ball
		//bigBall.SetActive(true);
	}

	public void ButtonShowTips(){

		tipsText.SetActive(true);
		Invoke("HideTips",2f);
	}

	public void HideTips(){
		
		tipsText.SetActive(false);
	}
}
