using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandInteraction : MonoBehaviour {

	//[SteamVR_DefaultAction("Squeeze")]
	//public SteamVR_Action_Single squeezeAction; //Single action, 1/0 press or not?

	public SteamVR_Action_Vector2 joyStickAction; //Since these aren't buttons. we need to store a value of how much we are getting from that action 


	//Swipe
	//public float swipeSum;
	//public float touchLast;
	public float touchCurrent;
	public float leftTouchCurrent;
	//public float distance;
	public bool hasSwipedLeft;
	public bool hasSwipedRight;
	public bool hasSwipedUp;
	public bool hasSwipedDown;

	public ObjectMenuManager objectMenuManager;
	private bool oculus;
	public bool displayMenu;

	// Use this for initialization
	void Start () {
		//Check if user uses Oculus
		if (UnityEngine.XR.XRDevice.model.Contains("Oculus")) 
		{
			oculus = true;
		} else
		{
			oculus = false;
		}
		displayMenu = false;

	}

	// Update is called once per frame
	void Update () {
		//Hide menu if user attempts to teleport
		if (SteamVR_Input._default.inActions.Teleport.GetStateDown(SteamVR_Input_Sources.RightHand)){
			objectMenuManager.HideMenu ();
		}

		if (SteamVR_Input._default.inActions.DisplayObjectMenu.GetStateDown(SteamVR_Input_Sources.RightHand)) 
		{
			objectMenuManager.ToggleMenu ();
		}

		//displayMenu = SteamVR_Input._default.inActions.DisplayObjectMenu;
		//if (SteamVR_Input._default.inActions.DisplayObjectMenu.GetStateDown(SteamVR_Input_Sources.LeftHand)) {
		Vector2 touchCurrent = joyStickAction.GetAxis (SteamVR_Input_Sources.RightHand);

			if (!hasSwipedRight) {
				if (touchCurrent.x > 0.5) {
					
					SwipeRight ();
					hasSwipedRight = true;
				 	hasSwipedLeft = false;				
				}
			}

			if (!hasSwipedLeft) {
				if (touchCurrent.x < -0.5) {
					SwipeLeft ();
					hasSwipedLeft = true;
					hasSwipedRight = false;
				}
			}

		if (touchCurrent.y < -0.5) {
			SwipeDown ();
		}
		if (touchCurrent.y > 0.5) {
			SwipeUp ();
		}
			
		if (touchCurrent.x == 0) 
		{
			hasSwipedLeft = false;
			hasSwipedRight = false;
		}

		if (SteamVR_Input._default.inActions.DisplayObjectMenu.GetStateUp(SteamVR_Input_Sources.RightHand))
		{
			objectMenuManager.ToggleMenu ();
		}

		if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(SteamVR_Input_Sources.RightHand)) 
		{
			SpawnObject ();
		}

		Vector2 leftTouchCurrent = joyStickAction.GetAxis (SteamVR_Input_Sources.LeftHand);

		if (leftTouchCurrent.x > 0.5) {
			RotateClockWise();
		}

		if (leftTouchCurrent.x < -0.5) {
			RotateAntiClockWise();
		}

	}


	void SpawnObject(){
		objectMenuManager.SpawnCurrentObject();
	}

	void SwipeLeft(){
		objectMenuManager.MenuLeft ();
		Debug.Log ("SwipeLeft");
	}

	void SwipeRight(){
		objectMenuManager.MenuRight ();
		Debug.Log ("SwipeRight");
	}

	void SwipeUp(){
		objectMenuManager.RaiseMenu ();
		Debug.Log ("SwipeUp");
	}

	void SwipeDown(){
		objectMenuManager.LowerMenu ();
		Debug.Log ("SwipeDown");
	}

	void RotateClockWise()
	{
		objectMenuManager.RotateClockWise ();
	}

	void RotateAntiClockWise()
	{
		objectMenuManager.RotateAntiClockWise ();
	}
}
