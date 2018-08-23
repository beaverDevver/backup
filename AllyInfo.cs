using Unity.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum ClassType {Soldier, Knight, Sniper, Berserker};
[Serializable]
public struct AllyInfo : IComponentData {
	public string name_;
	public Texture portrait_;
	public ClassType class_;
	public Ability primaryAbility_;
	public Ability specialAbility_;
}
/*
[Serializable]
public class AllyInfo : MonoBehaviour {
	[SerializeField] private string name_;
	[SerializeField] private Texture portrait_;
	[SerializeField] private ClassType class_;

	[SerializeField] private Ability primaryAbility_;
	[SerializeField] private Ability specialAbility_;

	
	/*
		


	*/
	// Use this for initialization
	/*void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string GetName () {
		return name_;
	}

	public Texture GetPortrait () {
		return portrait_;
	}

	public ClassType GetClass () {
		return class_;
	}

	public AbilityType GetPrimaryAbilityType () {
		return primaryAbility_.type_;
	}

	public AbilityType GetSpecialAbilityType () {
		return specialAbility_.type_;
	}


}*/
