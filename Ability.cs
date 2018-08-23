using System;
using Unity.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType {MeleeAttack/*Combat*/, RangeAttack/*Combat*/, Shield/*Transformer*/, Teleport/*Movement*/, Bomb/*Shootable*/};

[Serializable]
public struct Ability : IComponentData {
	public string name_;
	public string description_;

	public AbilityType type_;
	public List<Action> actions_;

	public class AbilityComponent : ComponentDataWrapper<Ability>{ }
}
/*
public class Ability : MonoBehaviour {
	public AbilityType type_;

	[SerializeField] private string name_;
	[SerializeField] private string description_;

	public List<Action> actions_;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public AbilityType GetType () {
		return type_;
	}

	public string GetName() {
		return name_;
	}

	public string GetDescrpition () {
		return description_;
	}
		//ability adds itself to owner's turn
	public void ActivateAbility (GameObject owner, GameObject target) {
		Turn turn = owner.GetComponent<Turn> ();
		if (turn == null) {
			//error message
			return;
		}

		foreach (Action a in actions_) {
			a.Initialize (owner, target);
			turn.AddAction (a);
		}
		/*
			getting turn to queue up ability
			getting turn to start having actions be executed
			having ActionExecutor delegate the execution of the actions
			turning combat into a system and use combatant for storing ally combat data
			movement will be used as data, using navmesh as system

			eventually need systems for transformation, etc..
		*/

		/*this is done for the most part
			need to add the required components for the combat system
			-> Turn to queue the actions for execution
			->Combat, Movement, etc. for executing the actions
			->BattleSystem to set up battle and have viable targets
			->Input or some other method of intiating and choosing actions
		*/
	//}
		
//}
