using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Duration : MonoBehaviour {

	public Text defaultText;
	private float lastInterval;
	AudioSource audioData;

	// Use this for initialization
	void Start () {
		lastInterval = Time.realtimeSinceStartup;
//		lastInterval = 543.431f;
		float 	minutes = lastInterval / 60;
		minutes = Mathf.Round (minutes);
		float	seconds = lastInterval - (minutes * 60);
		defaultText.text
		= "Thank you for playing." + "\n" +
			"Time Taken: " + "\n" + minutes.ToString () + "mins " + seconds.ToString("0.##") + " sec";
		audioData = GetComponent<AudioSource> ();
		audioData.Play (0);
	}
	
	// Update is called once per frame
	void Update () {
		{

		}
	}
}
