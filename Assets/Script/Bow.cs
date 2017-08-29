using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

	bool PositionSetting = false;
	bool isAttached = false;
	GameObject ParentObj;

	private Transform OriginStringTransform;
	private GameObject Arrow;

	public GameObject String;
	public GameObject StartPoint;
	public GameObject RightController;

	// Use this for initialization
	void Start () {
		OriginStringTransform = String.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckParent ();

	}

	void PullString()
	{
		if (isAttached) 
		{
			float dist = (StartPoint.transform.position - RightController.transform.position).magnitude;
			String.transform.localPosition = new Vector3(StartPoint.transform.localPosition.x, String.transform.localPosition.y, String.transform.localPosition.z) + new Vector3 (dist*5f, 0f, 0f);

			if (!Arrow.transform.parent) {
				Arrow.GetComponent<Rigidbody> ().velocity = Arrow.transform.forward * 15f * dist;
				Arrow.tag = "Item";
				isAttached = false;
				String.transform.localPosition = new Vector3 (1.416228f, -1.069222e-07f, 5.4137e-11f);
				String.transform.localRotation = Quaternion.Euler(new Vector3(0, -180, 0));
				Arrow = null;
			}

		}
	}

	void CheckParent()
	{
		if (transform.parent) {
			transform.FindChild ("Collider").gameObject.SetActive (false);
			GetComponent<BoxCollider> ().enabled = true;
			GetComponent<Rigidbody> ().isKinematic = true;

			if (ParentObj==null)
				ParentObj = transform.parent.gameObject;

			if (ParentObj != transform.parent.gameObject || !PositionSetting) 
			{
				transform.localPosition = new Vector3 (0, 0.068f, 0.129f);
				transform.localRotation = Quaternion.Euler (new Vector3 (45, 0, 0));
				PositionSetting = true;
				ParentObj = transform.parent.gameObject;
			}
			PullString ();
		} else {
			transform.FindChild ("Collider").gameObject.SetActive (true);
			GetComponent<BoxCollider> ().enabled = false;
			GetComponent<Rigidbody> ().isKinematic = false;
			PositionSetting = false;
			ParentObj = null;
			isAttached = false;
			if (Arrow != null) 
			{
				isAttached = false;
				String.transform.localPosition = new Vector3 (1.416228f, -1.069222e-07f, 5.4137e-11f);
				String.transform.localRotation = Quaternion.Euler(new Vector3(0, -180, 0));
				Arrow.transform.parent = null;
				Arrow.tag = "Item";
				Arrow = null;
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name.Contains ("Arrow") && col.gameObject.tag.Contains ("Right") || col.gameObject.tag.Contains ("Left")) 
		{
			Arrow = col.gameObject;
			col.gameObject.transform.parent = String.transform;
			col.transform.localPosition = new Vector3 (3.25f, 0, 0);
			col.transform.localRotation = Quaternion.Euler (new Vector3 (0, 90, 90));
			isAttached = true;
		}
	}

}
	
