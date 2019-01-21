using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour {

	public float timer;
	public GameObject spawn;
	public int spawnCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0f)
		{
			if (spawnCount <= 18) 
			{	
				Instantiate(spawn, new Vector3(17.293f, 2.055f, 18.383f), transform.rotation);
				timer = 2f;
				spawnCount++;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Boxes")) 
		{
			Rigidbody rb = other.gameObject.GetComponent<Rigidbody> ();
			rb.constraints = RigidbodyConstraints.None;
		}
	
	}


	void OnCollisionStay(Collision collision) {
		
		if (collision.gameObject.CompareTag ("Boxes")) 
		{
			// Assign velocity based upon direction of conveyor belt
			// Ensure that conveyor mesh is facing towards its local Z-axis
			float conveyorVelocity = 0.14f;
			Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

			//Keep constant speed
			if (rb.velocity.z > -2.5f) {
				rb.AddForce (conveyorVelocity * transform.forward, ForceMode.VelocityChange);
			}
	
		}
	}
}
