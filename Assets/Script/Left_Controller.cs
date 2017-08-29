using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Controller : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;

	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input ((int) trackedObj.index); }
	}

	private GameObject OnTriggerObj;

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (OnTriggerObj != null) 
		{
			if (Controller.GetPressDown (SteamVR_Controller.ButtonMask.Grip)) 
			{
				GripDown ();
			}

			if (Controller.GetPressUp (SteamVR_Controller.ButtonMask.Grip)) 
			{
				GripUp ();
			}
		}
		else 
		{
			GetComponent<BoxCollider> ().enabled = true;
		}
	}

	void GripDown(){
		if (OnTriggerObj.tag.Contains ("Item")) 
		{
			GetComponent<BoxCollider> ().enabled = false;
			OnTriggerObj.tag = "LeftItem";
			OnTriggerObj.transform.parent = transform;
		}
	}

	void GripUp(){
		if (OnTriggerObj.tag.Equals ("LeftItem")) 
		{
			GetComponent<BoxCollider> ().enabled = true;
			OnTriggerObj.transform.parent = null;
		}
		OnTriggerObj = null;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.name.Equals ("BowCollider")) 
		{
			OnTriggerObj = GameObject.Find ("Custom_Bow");
		}
		else 
		{
			OnTriggerObj = col.gameObject;
		}

	}

	void OnTriggerExit(Collider col)
	{
		OnTriggerObj = null;
	}

}
