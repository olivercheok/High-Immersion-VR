using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour {

	public float thrust;
	public Rigidbody rb;
	private GameObject trampoline;
	AudioSource audioData;
	// Use this for initialization
	void Start () {
		thrust = 400f;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Throwable")) 
		{
			print ("Blowing");
			rb = other.gameObject.GetComponent<Rigidbody>();
			rb.AddForce (transform.right * thrust, ForceMode.Acceleration);

			//rb.transform.LookAt (gameObject);
			//rb.AddRelativeForce (0, 0, thrust);
		}
	}
}
