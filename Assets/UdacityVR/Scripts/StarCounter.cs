using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCounter : MonoBehaviour {

	private int starCount = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StarCountUp() 
	{
		starCount++;
		print ("Number of stars collected: " + starCount);
	}

	public void StarCountReset () 
	{
		starCount = 0;
		print ("Resetting number of stars: " + starCount);
	}
}
