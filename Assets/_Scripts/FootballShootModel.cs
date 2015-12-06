using UnityEngine;
using System.Collections;

public class FootballShootModel : MonoBehaviour {
	public Camera cam;
	public float force=50f;

	void Start(){

		if(cam==null){

			cam=Camera.main;
		}

	}


	#region Touch
	protected virtual void OnEnable()
	{
		// Hook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe += OnFingerSwipe;
	}
	
	protected virtual void OnDisable()
	{
		// Unhook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe -= OnFingerSwipe;
	}
	
	public void OnFingerSwipe(Lean.LeanFinger finger)
	{
		// Make sure the info text exists
		if (gameObject != null)
		{



			Vector3 rbForce=finger.GetDeltaWorldPosition(force,cam);
			//rbForce+=new Vector3(0f,force,0f);

			GetComponent<Rigidbody>().AddForce(rbForce);
			
			
			
			
		}
	}
	#endregion
}
