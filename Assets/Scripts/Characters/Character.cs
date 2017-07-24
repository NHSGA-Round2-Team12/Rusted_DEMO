using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Character

Base class for all characters, including the player, different enemy types.

Purpose:

- Health management
- Death management

Each enemy type should have a class that inherits this to implement its own functions.
For example: The player can interact, some enemy may shoot, etc.
 
*/
public class Character : MonoBehaviour {

	[Header("Health")]
	public int maxHitpoints;
	[HideInInspector] int curHitpoints;

	public enum Character_Type {Human, Bot, Animal};
	[Header("Type")]
	public Character_Type charType;

	// Use this for initialization
	void Start () {
		curHitpoints = maxHitpoints;
	}

	// Does damage to character
	public void TakeDamage(int dmg){
		curHitpoints -= dmg;
		print ("Took " + dmg + " damage!");
		if (curHitpoints <= 0) {
			OnDeath ();
		}
	}

	// Destroy the character and do particle effects, etc
	public void OnDeath() {
		Destroy (gameObject);
	}
}
