using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPickUp : MonoBehaviour {

	public GameObject ball;
	public GameObject coinEffect;
	public BallReset ballReset;
	public int count;
	// Use this for initialization
	void Start () {
		

	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider colli) 
	{
		if (colli.name == "Ball") 
		{
			print ("star picked up");

			//good pratice to delete the particle system after it has done its part
			var effect = Instantiate (coinEffect, transform.position, transform.rotation);
			Destroy (effect.gameObject, 3);
			Destroy (gameObject);

		}
	}
}
