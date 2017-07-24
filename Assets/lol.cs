using UnityEngine;
using System.Collections;

public class lol : MonoBehaviour {
	//Variables
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F; 

	public float gravity = 20.0F;
	public float current_gravity = 20.0F;

	private Vector3 moveDirection = Vector3.zero;

	private CharacterController controller = GetComponent<CharacterController>();

	void Update() {
		// is the controller on the ground?
		if (controller.isGrounded) {
			//Feed moveDirection with input.
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			//Multiply it by speed.
			moveDirection *= speed;
			//Jumping
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;

		}
		//Applying gravity to the controller
		moveDirection.y -= current_gravity * Time.deltaTime;
		//Making the character move
		controller.Move(moveDirection * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			controller.isGrounded = true;
		}
	}
}
