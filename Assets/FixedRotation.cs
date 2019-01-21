using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour {

	Quaternion iniRot;
	// Use this for initialization
	void Start () {
		iniRot = transform.rotation;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.rotation = iniRot;
	}
}
