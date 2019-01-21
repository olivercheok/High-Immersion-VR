using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		StartCoroutine(Example());
		print ("Went past Couroutine example");
	}

	IEnumerator Example()
	{
		print("Testing*******: " + Time.time);
		yield return new WaitForSeconds(5);
		print("Testing*******: " + Time.time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Fade() 
	{
		Renderer renderer;
		renderer = GetComponent<Renderer> ();
		for (float f = 1f; f >= 0; f -= 0.1f) 
		{
			Color c = renderer.material.color;
			c.a = f;
			renderer.material.color = c;
		}
	}

}
