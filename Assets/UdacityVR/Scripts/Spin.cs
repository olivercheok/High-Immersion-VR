using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour {


	public float speed = 10f;
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (0, 90 * Time.deltaTime, 0);
	}
		
}
