using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	public float capeMaxDamage;
	public float capeRecoverRate;

	private float capeCurDamage;
	private bool capeActive;

	public new void Start() {
		capeActive = false;
		base.Start ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Interact ();
		}

		if (Input.GetButtonDown ("Cape")) {
			CapeOn ();
		} else if (Input.GetButtonUp ("Cape")) {
			CapeOff ();
		}
	}

	public new void TakeDamage(int dmg){
		//print ("Player takedamage");
		if (capeActive == true && capeCurDamage < capeMaxDamage) {
			capeCurDamage += dmg;
			//print ("block");
			if (capeCurDamage > capeMaxDamage) {
				
				capeCurDamage = capeMaxDamage;
				CapeOff ();
			}
		} else {
			base.TakeDamage (dmg);
		}
	}

	void Interact () {

	}
		

	public void CapeOff() {
		print ("cape off");
		capeActive = false;
	}

	public void CapeOn() {
		print ("cape on");
		capeActive = true;
	}
}
