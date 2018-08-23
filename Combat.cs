using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {
	/*
	private GameObject target_;

	private float damageDealt_;
	private bool attackCancelled_;
	// Use this for initialization
	void Start () {
		damageDealt_ = 0.0f;
		attackCancelled_ = false;
	}

	void OnEnable () {
		EventSystem.Connect (gameObject, Events.TurnCancelled, CancelAttack);
	}


	void OnDisable () {
		EventSystem.Disconnect (gameObject, Events.TurnCancelled, CancelAttack);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Attack (GameObject target) {
		target_ = target;
		StartCoroutine ("WaitForAttackCooldown");
	}

	public void CancelAttack (EventData data) {
		attackCancelled_ = true; 
	}

	public float GetAttackRange() {
		Weapon weapon = GetCurrentWeapon ();
		if (weapon) {
			return weapon.GetRange ();
		} else {
			return 0.0f;
		}
	}

	private void DealDamageToTarget () {
		Health targetHealth = target_.GetComponent<Health> ();
		if (targetHealth) {
			damageDealt_ = CalculateDamage (); 
			targetHealth.DealDamage (damageDealt_);

			//AttackEventData attackData = new AttackEventData (gameObject, target_, damageDealt_);
			//EventSystem.EventSend (gameObject, Events.CombatantAttacked, attackData);
		}
	}

	private float CalculateDamage () {
		Weapon weapon = GetCurrentWeapon ();
		if (weapon) {
			return weapon.GetDamage ();
		} else {
			return 0.0f;
		}
	}

	private Weapon GetCurrentWeapon () {
		Equipment equipment = GetComponent<Equipment> ();
		if (equipment) {
			return equipment.GetEquippedWeapon ();
		} else {
			return null;
		}
	}

	private IEnumerator WaitForAttackCooldown () {
		EventSystem.EventSend (gameObject, Events.StartAttackAnimation);
		DealDamageToTarget ();
		Debug.Log ("Starting cooldown");

		Weapon weapon = GetCurrentWeapon ();
		if (weapon) {
			float timer = weapon.GetAttackInterval ();
			while (timer > 0.0f) {
				timer -= Time.deltaTime;
				if (attackCancelled_) {
					break;
				}
				yield return null;
			}
		}
		Debug.Log ("Cool down over");
		if (attackCancelled_) {
			attackCancelled_ = false;
		} else {
			EventSystem.EventSend (gameObject, Events.AttackFinished);
		}
	}

	public float GetLastDamageDealt () {
		return damageDealt_;
	}


	public void ShootHitscan (GameObject target) {

	}*/




}
