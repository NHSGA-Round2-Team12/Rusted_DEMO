using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class PlayerMovementInput : MonoBehaviour
{
	private CharacterMovement m_Character;
	private bool m_Jump;


	private void Awake()
	{
		m_Character = GetComponent<CharacterMovement>();
	}


	private void Update()
	{
		if (!m_Jump)
		{
			// Read the jump input in Update so button presses aren't missed.
			m_Jump = Input.GetButtonDown("Jump");
			//if (m_Jump == true)
			//	print ("jump!");
		}
	}


	private void FixedUpdate()
	{
		// Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftControl);
		float h = Input.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		if (m_Jump == true)
			print ("jump!");
		m_Character.Move(h, crouch, m_Jump);
		m_Jump = false;
	}
}
