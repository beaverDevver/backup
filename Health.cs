using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Health : MonoBehaviour {
	public float maxHealth_;
	public currentHealth_;

	public class HealthComponent : ComponentDataWrapper<Health> {}
}

/*
	// Use this for initialization
	void Start () {
		currentHealth_ = maxHealth_;

	}

	void OnEnable () {

	}

	void OnDisable () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//
	public void DealDamage (float damage) {
		ChangeHealth (-damage);
		if (currentHealth_ <= 0.0f) {
			//EventSystem.EventSend (gameObject, Events.HealthIsZero, null);
		}
	}

	public void ChangeHealth (float amount) {
		currentHealth_ += amount;	
		if (currentHealth_ > maxHealth_) {
			ApplyOverheal ();
		}*
	/*	HealthChangeEventData healthEventData = new HealthChangeEventData (gameObject, amount, currentHealth_, maxHealth_);
		if (amount < 0) {
			EventSystem.EventSend (gameObject, Events.DamageTaken, healthEventData);
		} else {
			EventSystem.EventSend (gameObject, Events.DamageDealt, healthEventData);
		}*/
	/*}

	private void ApplyOverheal () {
			//there is no overheal yet
		currentHealth_ = maxHealth_;
	}

	public float GetHealthPercentage () {
		return currentHealth_ / maxHealth_;
	}

	public float GetHealth () {
		return currentHealth_;
	}

	public float GetMaxHealth () {
		return maxHealth_;
	}

}*/

/*public class HealthChangeEventData : EventData {
	public GameObject target_;
	public float amountChanged_;
	public float currentHealth_;
	public float maxHealth_;

	public HealthChangeEventData (GameObject target, float amount, float current, float max) {
		target_ = target;
		amountChanged_ = amount;
		currentHealth_ = current;
		maxHealth_ = max;
	}
}*/

