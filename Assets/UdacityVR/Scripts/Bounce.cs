using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

	public float thrust;
	public Rigidbody rb;
	private GameObject trampoline;
	// Use this for initialization
	void Start () {
		thrust = 1000f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Throwable")) 
		{
			rb = other.gameObject.GetComponent<Rigidbody>();
			rb.AddForce (transform.up * thrust);
		}
	}
}
