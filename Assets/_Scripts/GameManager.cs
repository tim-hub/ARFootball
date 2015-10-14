using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager instance=null;

	public bool arMode=false;
	// Use this for initialization
	void Start () {
		if(instance==null){ //do we have a game manager yet, if no
			instance=this;	//than this is the game manager
		}else if(instance!=this){ //is there is
			Destroy(gameObject); //than destroy this
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();

		}
	}
}
