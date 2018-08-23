using Unity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Turn : IComponentData {
	public TurnState state_;
	public Action currentAction_;

	public Queue<Action> actionQueue_;

	public class TurnComponent : ComponentDataWrapper<Turn> { }
}


public enum TurnState {Available, Starting, Executing}
//takes and executes actions
/*
public class Turn : MonoBehaviour {
	
	private Queue<Action> actionQueue_;

	private Action currentAction_;
	private TurnState currentState_;

	// Use this for initialization
	void Start () {
		actionQueue_ = new Queue<Action> ();

		//currentAction_ = null;
		currentState_ = TurnState.Available;




		//temporay to show ui info
		//EventSystem.EventSend (turnCard_.gameObject, Events.UIShowTurnCard);
	}

	void OnEnable () {
		EventSystem.Connect (gameObject, Events.ActionFinished, FinishAction);

		EventSystem.Connect (gameObject, Events.Death, RespondToDeath);
		//EventSystem.Connect (gameObject, Events.EnterRestState, DisableTurnUI);
		//EventSystem.Connect (gameObject, Events.EnterWaitingState, EnableTurnUI);
	}

	void OnDisable () {
		EventSystem.Disconnect (gameObject, Events.ActionFinished, FinishAction);

		EventSystem.Disconnect (gameObject, Events.Death, RespondToDeath);
		//EventSystem.Connect (gameObject, Events.EnterRestState, DisableTurnUI);
		//EventSystem.Connect (gameObject, Events.EnterDeployState, EnableTurnUI);
	}

	// Update is called once per frame
	void Update () {

	}

	//get turn information and initialze any variables needed
	private void StartTurn () {
		currentState_ = TurnState.Starting;
		currentAction_ = actionQueue_.Dequeue();
	}

	public void AddAction (Action newAction) {
		actionQueue_.Enqueue (newAction);
	}

	private void FinishTurn() {

		currentState_ = TurnState.Available;
		EventSystem.EventSend (gameObject, Events.EnterWaitingState);

	}

	public void RespondToDeath (EventData data) {
		CancelTurn ();
	}

	public void CancelTurn() {
		if(currentState_ != TurnState.Available || actionQueue_.Count > 0) {
			actionQueue_.Clear ();
			currentState_ = TurnState.Available;
		}
	}



	public void FinishAction (EventData data) {
		ExecuteNextAction ();
	}


	public bool CanAssignTurn() {
		return currentState_ == TurnState.Available;
	}


	public Action GetCurrentAction () {
		return currentAction_; 
	}

	public void ExecuteNextAction () {
		if (actionQueue_.Count == 0) {
			FinishTurn ();
			return;
		} else {
				//set to executing
			if (currentState_ == TurnState.Executing) {
				
			} else {
				currentState_ = TurnState.Executing;
			}
	
			currentAction_ = actionQueue_.Dequeue();

			/*switch (currentAction_.type_) {
			case ActionType.Move:
				StartMovementAction ();
				break;
			case ActionType.Attack:
				StartAttackAction ();
				break;
			case ActionType.Pickup:
				StartPickupAction ();
				break;
			case ActionType.EngageNPC:
				StartEngageNPCAction ();
				break;
			}*/


	//	}
//	}
	/*
	private void StartMovementAction () {
		Movement move = GetComponent<Movement> ();
		if (move) {
			currentAction_.isExecuting_ = true;

			//if attack turn, move within the weapon's range
			if (turnTypeDict_ [ActionType.Attack]) {
				Combat combat = GetComponent<Combat> ();
				if (combat) {
					float range = combat.GetAttackRange ();
					move.SetStoppingDistance (range);
				}
			} else {
				move.SetStoppingDistance ();
			}
			//update turn data
			turnData_.action_ = ActionType.Move;

			EventSystem.EventSend (gameObject, Events.MovementStarted);
			
			move.MoveTo (currentAction_.actionPosition_);
		}
	}

	private void StartAttackAction () {

		Combat combat = GetComponent<Combat> ();
		if (combat) {
			//update turn data
			turnData_.action_ = ActionType.Attack;

			EventSystem.EventSend (gameObject, Events.AttackStarted);
			combat.Attack (currentAction_.actionObject_);
		}
	}


	//we need to do something here to complete pickup -morning, 5/8/2017 
	private void StartPickupAction () {
		//2/11/2018 wont work because player has inventory
		Inventory inv = GetComponent<Inventory> ();
		if (inv) {
			//update turn data
			turnData_.action_ = ActionType.Pickup;

			EventSystem.EventSend (gameObject, Events.PickupStarted);
			currentAction_.isExecuting_ = true;
			inv.Pickup (currentAction_.actionObject_);
		}
	}

	private void StartEngageNPCAction () {
		Talkable talker = currentAction_.actionObject_.GetComponent<Talkable> ();
		talker.StartConversation (gameObject);
	}
	*/








//TO BE DELETED
/*
 * public enum ActionType {Move, Attack, Pickup, EngageNPC};
public class AllyAction {
	//variables for logic for taking the action
	public Vector3 actionPosition_;
	public GameObject actionObject_;
	//variables for determing when and how to execute
	public ActionType type_;
	public bool isExecuting_;
	//variables used to tell turn to start and stop actions
	private Turn turn_;



}
 * 
	public AllyAction (ActionType type, GameObject actionObject, Vector3 position, Turn turn) {
		isExecuting_ = false;
		type_ = type;
		actionObject_ = actionObject;
		actionPosition_ = position;
		turn_ = turn;
	}

	//private AllyAction currentAction_; 	
//actiontype dictionary
	//check actions before turn starts
		//if action is taken during this turn, marked as true
	private Dictionary<ActionType, bool> turnTypeDict_;

		//initialize action type list
		turnTypeDict_ = new Dictionary<ActionType, bool> ();
		foreach (ActionType action in System.Enum.GetValues(typeof(ActionType))) {
			turnTypeDict_[action] = false;
		}
		//in start turn
		foreach (AllyAction action in actionQueue_) {
			turnTypeDict_ [action.type_] = true;
		}

//in finish turn
		foreach (ActionType action in System.Enum.GetValues(typeof(ActionType))) {
			turnTypeDict_[action] = false;
		}
		//in cancel turn
					foreach (ActionType action in System.Enum.GetValues(typeof(ActionType))) {
				turnTypeDict_ [action] = false;
			}


//turn ui stuff that should have been communicated with messages and events and stufff like that
	//use for storing info about the turn
	//then sent to UI when changes occur
	private TurnUIEventData turnData_;
	private TurnUI turnCard_;


		//initialize some of our turn data, some info doesn't change
		turnData_ = new TurnUIEventData (gameObject, "Ally", ActionType.Move, 10, 10, 
					"Weapon", WeaponType.Melee, 0, 0);


//called in update
UpdateTurnData ();
	private void UpdateTurnData () {
		Health health_ = GetComponent<Health> ();
		Combat combat = GetComponent<Combat> ();
		Equipment equipment = GetComponent<Equipment> ();
		Weapon weapon = equipment.GetEquippedWeapon ();

		turnData_.currentHealth_ = health_.GetHealth();
			//dont need to update every frame, but okay until later
		turnData_.maxHealth_ = health_.GetMaxHealth ();

		turnData_.damageDealt_ = combat.GetLastDamageDealt ();

		if (weapon) {
			turnData_.weaponName_ = weapon.GetWeaponName ();
			turnData_.weaponType_ = weapon.GetWeaponType ();
		} else {
			turnData_.weaponName_ = "";
			turnData_.weaponType_ = WeaponType.Melee;
		}

		EventSystem.EventSend (turnCard_.gameObject, Events.UITurnActionUpdate, new TurnUIEventData (turnData_));
	}
//in start
		GameObject obj = GameObject.Find ("TurnCard");
		if (obj) {
			turnCard_ = obj.GetComponent<TurnUI> ();
		}

	
	//in start turn
		if (turnCard_) {
			EventSystem.EventSend (turnCard_.gameObject, Events.UITurnStart, new TurnUIEventData (turnData_));
		}
//in finish turn
		if (turnCard_) {
			EventSystem.EventSend (turnCard_.gameObject, Events.UITurnFinished, new TurnUIEventData (turnData_));
		}

//in cancel turn
			if (turnCard_) {
				EventSystem.EventSend (gameObject, Events.EnterWaitingState);
			}

			if (turnCard_) {
				EventSystem.EventSend (gameObject, Events.TurnCancelled);
			}
}

//in execute turn
			if (turnCard_) {
				EventSystem.EventSend (turnCard_.gameObject, Events.UITurnActionUpdate, new TurnUIEventData (turnData_));
			}


	public void EnableTurnUI (EventData data) {
		if (turnCard_) {

			UpdateTurnData ();
			EventSystem.EventSend (turnCard_.gameObject, Events.UIShowTurnCard);
		}
	}

	public void DisableTurnUI (EventData data) {
		if (turnCard_) {
			//EventSystem.EventSend (turnCard_.gameObject, Events.UIHideTurnCard);
		}
	}


	*/

//}
