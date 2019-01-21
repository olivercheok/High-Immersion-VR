using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angle : MonoBehaviour {

	public Text displayAngle;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		displayAngle.text = "Rotation on X: " + Mathf.Round(transform.rotation.x * 1000f) / 1000f + "\n" +
			"Rotation on Y: " + Mathf.Round(transform.rotation.y * 1000f) / 1000f + "\n" +
			"Rotation on Z: " + Mathf.Round(transform.rotation.z * 1000f) / 1000f + "\n";
	}
}
