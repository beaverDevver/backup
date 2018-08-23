using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private float defaultStoppingDistance_;

	private UnityEngine.AI.NavMeshAgent navAgent_;

	private Vector3 positionRelativeToPlayer_;
	private Vector3 destination_;

	private bool isFollowingPlayer_;
	private bool isMoving_;

	// Use this for initialization
	void Start () {

		navAgent_ = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		defaultStoppingDistance_ = navAgent_.stoppingDistance;
		isFollowingPlayer_ = false;
		navAgent_.enabled = false;
		isMoving_ = false;
	}
	void OnEnable () {
		EventSystem.Connect (gameObject, Events.TurnCancelled, CancelMovement);
	}

	void OnDisable () {
		EventSystem.Disconnect (gameObject, Events.TurnCancelled, CancelMovement);
	}
	// Update is called once per frame
	void Update () {
		if (isMoving_) {
			if (HasReachedDestination()) {
				isMoving_ = false;
				navAgent_.isStopped = true;
				EventSystem.EventSend (gameObject, Events.MovementFinished);
			}
		}
	}

	public void MoveTo (Vector3 destination) {
		isFollowingPlayer_ = false;
		isMoving_ = true;
		navAgent_.SetDestination (destination);
	}
	/// <summary>
	/// Sets the stopping distance. Providing no parameter sets it to default
	/// </summary>
	/// <param name="distance">Distance.</param>
	public void SetStoppingDistance (float distance= -0.1f) {
		if (distance < 0.0f) {
			navAgent_.stoppingDistance = defaultStoppingDistance_;
		} else {
			navAgent_.stoppingDistance = distance; 
		}
	}

	private bool HasReachedDestination () {
		if (navAgent_.pathPending == false) {
			if (navAgent_.remainingDistance <= navAgent_.stoppingDistance) {
				if (navAgent_.hasPath == false || navAgent_.velocity.sqrMagnitude == 0.0f) {
					return true;
				}
			}
		}
		return false;
	}

	public void CancelMovement (EventData data) {
		isMoving_ = false;
	}

	public float GetRemaingingDistance(){
		return navAgent_.remainingDistance;
	}

	public float GetTimeRemaining () {
		return navAgent_.remainingDistance / navAgent_.speed;
	}

	public bool IsAllyMoving () {
		return isMoving_;
	}
}
