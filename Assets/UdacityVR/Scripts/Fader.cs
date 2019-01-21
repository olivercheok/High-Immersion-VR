using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

	public GameObject obj;
	private bool canFade;
	private Color alphaColor;
	public Animator anim;
	public Conveyor conveyor;

	public void Start()
	{
		alphaColor = obj.GetComponent<MeshRenderer>().material.color;
		alphaColor.a = 0;

		anim = GetComponent<Animator> ();
	}
	public void Update()
	{

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("Ground"))
		{
			anim.Play ("Fade");
			conveyor = GameObject.FindGameObjectWithTag ("Conveyor").GetComponent<Conveyor> ();
			conveyor.spawnCount--;

			Destroy (gameObject, this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length);
		}
	}
}
