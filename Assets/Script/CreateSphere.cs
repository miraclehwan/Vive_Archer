using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSphere : MonoBehaviour {

	public GameObject Sphere;
	private int i=0;


	// Use this for initialization
	void Start () 
	{
		
		StartCoroutine (Create());
	}

	IEnumerator Create()
	{
		while(i<10)
		{
			GameObject NewSphere = (GameObject) Instantiate (Sphere, transform.position, transform.rotation);
			NewSphere.GetComponent<Rigidbody> ().AddForce (transform.forward * 15f, ForceMode.Impulse);
			i++;
			yield return new WaitForSeconds (5);
		}
	}


}
