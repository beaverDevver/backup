
using Unity.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Stats : IComponentData {
	public float attack_;
	public float defense_;
	public float speed_;

	public class StatsComponent : ComponentDataWrapper<Stats> {}
}
	/*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float GetAttack () {
		return attack_;
	}

	public float GetDefense () {
		return defense_;
	}

	public float GetSpeed () {
		return speed_;
	}

	public void SetAttack (float value) {
		attack_ = value;
	}

	public void SetDefense (float value) {
		defense_ = value;
	}

	public void SetSpeed (float value) {
		speed_ = value;
	}

	public void IncreaseAttack (float amount) {
		attack_ = attack_ + amount;
	}

	public void IncreaseDefense (float amount) {
		defense_ = defense_ + amount;
	}

	public void IncreaseSpeed (float amount) {
		speed_ = speed_ + amount;
	}

}*/
