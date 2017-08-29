using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	bool PositionSetting = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckParent ();
	}

	void CheckParent()
	{
		if (transform.parent && !transform.parent.gameObject.name.Equals("Arrows")) {
			GetComponent<Rigidbody> ().isKinematic = true;
			if (!PositionSetting) {
				transform.localPosition = new Vector3 (0, -0.229f, 0.145f);
				transform.localRotation = Quaternion.Euler (new Vector3 (60, 0, 0));
				PositionSetting = true;
			}
		} else {
			GetComponent<Rigidbody> ().isKinematic = false;
			PositionSetting = false;
		}
	}
}
