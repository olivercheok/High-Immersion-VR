using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectMenuManager : MonoBehaviour {

	public List<GameObject> objectList;
	public List<GameObject> objectPrefabList;
	public int currentObject = 0;
	private bool displayStatus = false;
	private double positionY;

	private int[] maxCount;
	private int[] currentCount;

	AudioSource successAudio;
	AudioSource failAudio;

	// Use this for initialization
	void Start () {
		
		// Create a temporary reference to the current scene.
		Scene currentScene = SceneManager.GetActiveScene ();

		// Retrieve the name of this scene.
		string sceneName = currentScene.name;

		setMaxCount (sceneName);
		setCurrentCount ();

		foreach (Transform child in transform) {
			objectList.Add (child.gameObject);
		}

		AudioSource[] audioData = GetComponents<AudioSource> ();
		successAudio = audioData [1];
		failAudio = audioData [0];
	}

	public void setMaxCount(string level) 
	{
		switch (level) 
		{
		// Metal, Wood, Trampoline, Fan
		case ("Scene1"):
			maxCount = new int[] { 2, 2, 0, 0 };
			break;
		case ("Scene2"):
			maxCount = new int[] { 4, 2, 0, 1 };
			break;
		case ("Scene3"):
			maxCount = new int[] { 1, 1, 1, 0 };
			break;
		case ("Scene4"):
			maxCount = new int[] { 1, 1, 0, 1 };
			break;
		default:
			maxCount = new int[] { 4, 4, 4, 4 };
			break;
		}

	}

	public void setCurrentCount()
	{
		currentCount = new int[] { 0, 0, 0, 0};
	}

	public void ToggleMenu() {
		displayStatus = !displayStatus;
		objectList [currentObject].SetActive (displayStatus);	
	}

	public void HideMenu() {
		objectList [currentObject].SetActive (false);	
	}

	public void MenuLeft() {

		objectList [currentObject].SetActive (false);
		currentObject--;
		if (currentObject < 0) {
			currentObject = objectList.Count - 1;
		}
		objectList [currentObject].SetActive (true);

	}

	public void MenuRight() {

		objectList [currentObject].SetActive (false);
		currentObject++;
		print (currentObject);
		if (currentObject > (objectList.Count - 1)) {
			currentObject = 0;
		}
		objectList [currentObject].SetActive (true);
	}

	public void LowerMenu() 
	{
		if (transform.position.y >= -0.3f)
		transform.position = new Vector3 (transform.position.x, transform.position.y - 0.01f, transform.position.z);
	}

	public void RaiseMenu() 
	{
		if (transform.position.y <= 2f)
		transform.position = new Vector3 (transform.position.x, transform.position.y + 0.01f, transform.position.z);
	}

	public void RotateClockWise() 
	{
		transform.Rotate( new Vector3(0, 1, 0), Space.Self );
	}

	public void RotateAntiClockWise() 
	{
		transform.Rotate( new Vector3(0, -1, 0), Space.Self );
	}

	public void SpawnCurrentObject()
	{
		//only if menu is displayed then allow spawning
		if (displayStatus) 
		{
			//Remove oldest object when object hits maximum spawn count
			if (currentCount[currentObject] >= maxCount[currentObject]) 
			{
				Destroy (GameObject.Find (string.Concat (objectPrefabList [currentObject].name, "(Clone)")));
				//Do not go below zero
				if (currentCount[currentObject] != 0)
				{
					currentCount [currentObject]--;
				}
				failAudio.Play (0);
			}

			//Spawn object only if within maximum limit
			if (currentCount[currentObject] < maxCount[currentObject]) 
			{
				Instantiate (objectPrefabList [currentObject], objectList [currentObject].transform.position, objectList [currentObject].transform.rotation);
				currentCount [currentObject]=currentCount [currentObject] + 1;
				successAudio.Play (0);
			}
				
		
		}

	}
	// Update is called once per frame
	void Update () {


	}
}
