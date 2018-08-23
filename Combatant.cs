using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatantType {Ally, Enemy};

/*
this script, Combatant, talks to the battle system for the gameobject
it's intended to handle being added and removed from the battle and will
be how other scripts communicate with the battle system

the other script, COmbat, imnplements weapons and may be reworked in the future
-Mick 11/30/2017
*/

public class Combatant : MonoBehaviour {
	private bool inBattle_;
	private BattleSystem battleSystem_;
	CombatantType combatantType_;

	public string combatantName_;
	public Sprite combatantIcon_;
	public Color combatantColor_;


	void Start () {
		inBattle_ = false;
		GetBattleSystem ();

		if (gameObject.tag == "Ally") {
			combatantType_ = CombatantType.Ally;
		} else if (gameObject.tag == "Enemy") {
			combatantType_ = CombatantType.Enemy;
		}
	}

	void OnEnable () {
		EventSystem.Connect (gameObject, Events.Death, CombatantDeath);
		EventSystem.Connect(gameObject, Events.DamageTaken, DispatchDamageTaken );
		EventSystem.Connect(gameObject, Events.DamageDealt, DispatchDamageDealt);
		EventSystem.Connect(gameObject, Events.CombatantAttacked, CombatantAttack);
	}

	void OnDisable() {
		EventSystem.Disconnect (gameObject, Events.Death, CombatantDeath);
		EventSystem.Disconnect(gameObject, Events.DamageTaken, DispatchDamageTaken );
		EventSystem.Disconnect(gameObject, Events.DamageDealt, DispatchDamageDealt);
		EventSystem.Disconnect(gameObject, Events.CombatantAttacked, CombatantAttack);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void AddToBattle () {
		GetBattleSystem ();
		if (inBattle_ == false) {
			battleSystem_.AddCombatant (gameObject, combatantType_);
			inBattle_ = true;
		}
	}

	public void RemoveFromBattle () {
		if (inBattle_ == true) {
			battleSystem_.RemoveCombatant (gameObject, combatantType_);
			inBattle_ = false;
		}
	}

	public List<GameObject> GetTargets () {
		if (combatantType_ == CombatantType.Ally) {
			return battleSystem_.GetEnemyCombatants ();
		} else if (combatantType_ == CombatantType.Enemy) {
			return battleSystem_.GetAllyCombatants ();
		} else {
			return null;
		}
	}
	public void CombatantDeath (EventData data) {
		RemoveFromBattle ();
		DispatchEventToBattleSystem (Events.Death, data);
	}

	public void CombatantAttack (EventData data) {
		DispatchEventToBattleSystem (Events.CombatantAttacked, data);
	}

	public void DispatchDamageTaken (EventData data) {
		DispatchEventToBattleSystem (Events.DamageTaken, data);
	}

	public void DispatchDamageDealt (EventData data) {
		DispatchEventToBattleSystem (Events.DamageDealt, data);
	}


	public List<GameObject> GetTeammates () {
		if (combatantType_ == CombatantType.Ally) {
			return battleSystem_.GetAllyCombatants ();
		} else if (combatantType_ == CombatantType.Enemy) {
			return battleSystem_.GetEnemyCombatants ();
		} else {
			return null;
		}
	}
	//probably temporary, needed from adding an enemy to battle system in Start function
	//later will probably have dedicated enemy spawners
	private void GetBattleSystem () {
		GameObject battleObject = GameObject.Find ("BattleSystem");
		if (battleObject) {
			battleSystem_ = battleObject.GetComponent<BattleSystem> ();
			if (battleSystem_ == null) {
				Debug.Log ("Battle System object or component not found. -Combatant::Start");
			}
		}
	}

	private void DispatchEventToBattleSystem (string eventName, EventData data) {
		EventSystem.EventSend (battleSystem_.gameObject, eventName, data);
	}

	public string GetName () {
		return combatantName_;
	}

	public Sprite GetIconImage ()  {
		return combatantIcon_;
	}

	public Color GetColor () {
		return combatantColor_;
	}
}
