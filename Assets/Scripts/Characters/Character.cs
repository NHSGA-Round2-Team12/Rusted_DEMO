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

	[Header("References")]
	public GameObject damageEffect;
	public GameObject deathEffect;

	// Use this for initialization
	public void Start () {
		curHitpoints = maxHitpoints;
	}

	// Does damage to character
	public void TakeDamage(int dmg){
		curHitpoints -= dmg;
		if (damageEffect != null) {
			GameObject particles = Instantiate (damageEffect, transform.position, transform.rotation);
			Destroy (particles, particles.GetComponent<ParticleSystem> ().duration);
		}
		//print ("Took " + dmg + " damage!");
		if (curHitpoints <= 0) {
			OnDeath ();
		}
	}

	// Destroy the character and do particle effects, etc
	public void OnDeath() {
		if (deathEffect != null) {
			GameObject particles = Instantiate (deathEffect, transform.position, transform.rotation);
			Destroy (particles, particles.GetComponent<ParticleSystem> ().duration);
		}
		Destroy (gameObject);
	}
}
