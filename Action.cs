using Unity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType {Attack, Move, Transform, Wait, UseCharge};


[Serializable] 
public struct Action : IComponentData {
	public ActionType type_;
	public GameObject owner_;
	public GameObject target_;
	public Vector3 position_;
	public Vector3 targetPosition_;
	public float amount_;
	public int count_;

	public class ActionComponent : ComponentDataWrapper<Action> {}

}
/*
[System.Serializable]
public class Action : MonoBehaviour {

	public ActionType type_;
	public GameObject owner_;
	public GameObject target_;
	public Vector3 position_;
	public Vector3 targetPosition_;
	public float amount_;
	public int count_;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Initialize (GameObject owner, GameObject target) {
		owner_ = owner;
		target_ = target;
		position_ = owner_.transform.position;
		targetPosition_ = target_.transform.position;
	}
}*/
