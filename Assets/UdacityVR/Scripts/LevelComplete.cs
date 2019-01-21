using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;

public class LevelComplete : MonoBehaviour {

	public BallReset ballReset;
	public Text winText;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if ((other.gameObject.CompareTag("Throwable")) && (ballReset.starCount >= 2))
		{
			
			// Create a temporary reference to the current scene.
			Scene currentScene = SceneManager.GetActiveScene ();

			// Retrieve the name of this scene.
			string sceneName = currentScene.name;

			switch (sceneName) {
			case ("Scene1"):
				SteamVR_LoadLevel.Begin ("Scene2");
				break;
			case ("Scene2"):
				SteamVR_LoadLevel.Begin ("Scene3");
				break;
			case ("Scene3"):
				SteamVR_LoadLevel.Begin ("Scene4");
				break;
			case ("Scene4"):
				SteamVR_LoadLevel.Begin ("Scene5");
				break;
			default:
				SteamVR_LoadLevel.Begin ("Scene1");
				break;
			}

		}
	}
}
