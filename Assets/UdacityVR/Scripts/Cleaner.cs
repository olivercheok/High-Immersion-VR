using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {
	public GameObject[] boxes;
	public Conveyor conveyor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Throwable")) 
		{
			//Clear all boxes if ball hits UdacityBox
			print("Ball touches Udacity Box");
			boxes = GameObject.FindGameObjectsWithTag ("Boxes");
			foreach (GameObject item in boxes) {
				print ("Item: " + item);
				Destroy (item);
			}
			conveyor = GameObject.FindGameObjectWithTag ("Conveyor").GetComponent<Conveyor> ();
			conveyor.spawnCount = 0;
		}
	}
}
