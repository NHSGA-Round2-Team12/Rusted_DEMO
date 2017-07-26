using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMovementInput : MonoBehaviour {

	[Header("Variables")]
	[Range(1f, 20f)] public float detectDistance;
	[Range(1f, 30f)] public float chaseDistance;
	public bool isPatrolling;
	[Range(5f, 50f)] public float patrolRange;

	private Vector2 _startpos;
	private bool _patrollingRight;
	private CharacterMovement _charMove;
	private Player _playerRef;
	public enum Police_State
	{
		Idle,
		Patrolling,
		Alert,
		Engaging,
	}
	private Police_State state = Police_State.Idle;

	// Use this for initialization
	void Start () {
		_patrollingRight = true;
		_charMove = GetComponent<CharacterMovement> ();
		_startpos = transform.position;
		_playerRef = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void StateDetect() {
		// If engaging and out of range, go back to alert
		if (state == Police_State.Alert) {
			if (Vector2.Distance ((Vector2)_playerRef.transform.position, (Vector2)transform.position) > chaseDistance) {
				print ("ALERT!");
				state = Police_State.Alert;
			}
		}
		// Look ahead, do we detect the player?

		// If detected, change our state to engaging

		// If spent too long alert, revert to patrolling/idle
	}

	void FixedUpdate() {
		// If did not detect and patrolling, move towards direction
		if (state == Police_State.Patrolling) {
			
			//_charMove.Move()
		}

		// If we are engaging, look where the player is
	}
}
