using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class BallReset : MonoBehaviour {

	private Vector3 initialPosition;
	public GameObject respawnPrefab;
	public GameObject[] collectibles;
	protected List<Vector3> list = new List<Vector3>();
	public int starCount;
	public Text countText;
	public Text loseText;
	public Text winText;

	// Anti Cheat mechanism
	private Boolean FirstTest;
	private Boolean SecondTest;
	private Boolean grabCount;
	private Boolean grabCountActive;
	Renderer thisRend;
	Renderer goalRend;
	public GameObject goal;

	AudioSource audioData;

	// Use this for initialization
	void Start () 
	{
		audioData = GetComponent<AudioSource> ();
		NewLevel (1);
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
		{
			Debug.Break();
		}
	}

	public void NewLevel(int level) 
	{
		//Save Starting Ball position
		initialPosition = transform.position;

		//Save records of collectible locations
		collectibles = GameObject.FindGameObjectsWithTag ("Collectible");
		foreach (GameObject respawn in collectibles) {
			list.Add (respawn.transform.position);
		}
		foreach (Vector3 item in list) { print (item); } // prints all items in the list
		collectibles = new GameObject[0];



	}


	//Research: Chose OnTriggerEnter because Ball bounces which cause OnCollisionEnter to perform twice causing errors.
	//void OnCollisionEnter(Collision col)
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag ("Ground")) {

			audioData.Play (0);
			//Reset velocity and position of ball when it touches ground
			Rigidbody rigidbody = gameObject.GetComponent<Rigidbody> ();
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			gameObject.transform.position = initialPosition;

			//Reset all collectibles
			Respawn();
			collectibles = new GameObject[0];

			//Reset star count
			starCount = 0;

			//reset Cheat Mechanism
			FirstTest = false;
			SecondTest = false;
			thisRend = GetComponent<Renderer>();
			thisRend.material.SetColor("_Color", Color.white);
			goal.layer = 0;
		}

		if (col.gameObject.CompareTag ("Collectible")) 
		{
			starCount = starCount + 1;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.CompareTag ("FirstTest")) 
		{
			FirstTest = true;
		}

		if (col.gameObject.CompareTag ("SecondTest")) 
		{
			if (FirstTest) 
			{
				SecondTest = true;
			}
			else 
			{
				SecondTest = false;
			}
			StartCoroutine ("AntiCheat");
		}

	}
	void Respawn() 
	{	
		collectibles = GameObject.FindGameObjectsWithTag ("Collectible");


		foreach (GameObject respawn in collectibles)
		{	
			Destroy (respawn);
		}

		for(int i=0; i < list.Count; i++)
		{
			Instantiate(respawnPrefab, list[i], transform.rotation);
		}



	}

	public void AntiCheat() {
		//grabCount active only after exit of invisible collider
		//if (grabCount >= 1 && grabCountActive) 
		{		
			thisRend = GetComponent<Renderer> ();
			//change ball colour, set as inactive
			if ((FirstTest&&!SecondTest) || (FirstTest&&SecondTest))
			{
				//Make Goal's layer as Uninteractable
				goal.layer = 9;
				thisRend.material.SetColor ("_Color", Color.red);
			} else {
				thisRend.material.SetColor ("_Color", Color.white);
			}
		}
	}
}
