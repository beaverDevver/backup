using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BattleSystem : MonoBehaviour {


	private List<GameObject> allyCombatants_;
	private List<GameObject> enemyCombatants_;

	//for handling ui events
	//battle system will receive all events related to combat from every combatant 
	//it will relay these events to the ui
	private GameObject combatUI_;


	// Use this for initialization
	void Start () {
		allyCombatants_ = new List<GameObject>();
		enemyCombatants_ = new List<GameObject> ();

		combatUI_ = GameObject.Find ("CombatUI");
		if (combatUI_ == null) {
			Debug.Log ("Could not find object CombatUI. Required by BattleSystem");
		}
	}

	void OnEnable () {
		EventSystem.Connect (gameObject, Events.Death, DispatchCombatantDeath);
		EventSystem.Connect(gameObject, Events.DamageTaken, DispatchDamageTaken );
		EventSystem.Connect(gameObject, Events.DamageDealt, DispatchDamageDealt);
		EventSystem.Connect(gameObject, Events.CombatantAttacked, DispatchCombatantAttack);
	}

	void OnDisable () {
		EventSystem.Disconnect (gameObject, Events.Death, DispatchCombatantDeath);
		EventSystem.Disconnect(gameObject, Events.DamageTaken, DispatchDamageTaken );
		EventSystem.Disconnect(gameObject, Events.DamageDealt, DispatchDamageDealt);
		EventSystem.Disconnect(gameObject, Events.CombatantAttacked, DispatchCombatantAttack);
	}

	// Update is called once per frame
	void Update () {
	}

	public void AddCombatant (GameObject combatant, CombatantType type) {
		switch (type) {
		case CombatantType.Ally:
			allyCombatants_.Add (combatant);
			break;
		case CombatantType.Enemy:
			enemyCombatants_.Add (combatant);
			break;
		}
		//send this event to all combatants
		CombatantAddedEventData data = new CombatantAddedEventData (combatant, type);
		foreach (GameObject ally in allyCombatants_) {
			if (ally) {
				EventSystem.EventSend (ally, Events.CombatantAdded, data);
			}
		}
		foreach (GameObject enemy in enemyCombatants_) {
			if (enemy) {
				EventSystem.EventSend (enemy, Events.CombatantAdded, data);
			}
		}
		DispatchEventToCombatUI (Events.CombatantAdded, data);
	}

	public void RemoveCombatant (GameObject combatant, CombatantType type) {
		switch (type) {
		case CombatantType.Ally:
			if(allyCombatants_.Contains(combatant)) {
				allyCombatants_.Remove(combatant);
			}
			break;
		case CombatantType.Enemy:
			if (enemyCombatants_.Contains (combatant)) {
				enemyCombatants_.Remove (combatant);
			}
			break;
		}
		//send this event to all combatants
		CombatantRemovedEventData data = new CombatantRemovedEventData (combatant, type);
		foreach (GameObject ally in allyCombatants_) {
			EventSystem.EventSend (ally, Events.CombatantRemoved, data);
		}
		foreach (GameObject enemy in enemyCombatants_) {
			EventSystem.EventSend (enemy, Events.CombatantRemoved, data);
		}
		DispatchEventToCombatUI (Events.CombatantRemoved, data);
	}

	public List<GameObject> GetAllyCombatants () {
		return allyCombatants_;
	}

	public List<GameObject> GetEnemyCombatants () {
		return enemyCombatants_;
	}

	public void DispatchCombatantDeath (EventData data) {
		DispatchEventToCombatUI(Events.Death , data);
	}

	public void DispatchDamageTaken (EventData data) {
		DispatchEventToCombatUI(Events.DamageTaken, data);
	}

	public void DispatchDamageDealt (EventData data) {
		DispatchEventToCombatUI(Events.DamageDealt , data);
	}

	public void DispatchCombatantAttack (EventData data) {
		DispatchEventToCombatUI(Events.CombatantAttacked , data);
	}

	private void DispatchEventToCombatUI (string eventName, EventData data) {
		EventSystem.EventSend (combatUI_, eventName, data);
	}

}

public class CombatantAddedEventData: EventData {
	public GameObject combatant_;
	CombatantType type_;

	public CombatantAddedEventData (GameObject combatant, CombatantType type) {
		combatant_ = combatant;
		type_ = type;
	}
}

public class CombatantRemovedEventData: EventData {
	public GameObject combatant_;
	CombatantType type_;

	public CombatantRemovedEventData (GameObject combatant, CombatantType type) {
		combatant_ = combatant;
		type_ = type;
	}
}
