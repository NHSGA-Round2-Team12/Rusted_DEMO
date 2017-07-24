using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Interactable

Base class for all objects that can be interacted by the player.

Purpose:

*/
public class Interactable : MonoBehaviour {

	public bool canInteract = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InteractFunction() {
		print ("InteractFunction");
	}
}
