using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*	Rainzone
 * 
 * 	A script for defining where rain happens.
 *  Deals damage to bot characters as defined by Character_Type.
 * 
 */

public class RainZone : MonoBehaviour {

	public int damage;
	public float cooldown;


	private Collider2D _selfCol;

	// Use this for initialization
	void Start () {
		_selfCol = GetComponent<Collider2D> ();
		StartCoroutine (DoDamage ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator DoDamage(){

		Collider2D[] cols = new Collider2D[20];
		ContactFilter2D cf = new ContactFilter2D();
		Physics2D.OverlapCollider (_selfCol, cf, cols);
		foreach (Collider2D col in cols) {
			if (col == null)
				continue;
			
			Player character = col.GetComponent<Player> ();
			// If the player is in zone
			if (character != null && character.charType == Character.Character_Type.Bot) {
				// Raycast from the top to the player
				//Ray ray = new Ray (new Vector2(character.transform.position.x, transform.position.y + transform.lossyScale.y * 0.5f), -character.transform.up);
				RaycastHit2D raycastHit = Physics2D.Raycast (new Vector2(character.transform.position.x, transform.position.y + transform.lossyScale.y * 0.5f), -transform.up);
				if (raycastHit != null && raycastHit.collider == col)
					character.TakeDamage (damage);
			}
		}

		yield return new WaitForSeconds (cooldown);
		StartCoroutine (DoDamage ());
	}
}
