using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public enum Factions {Ally, Enemy}


public class Combatant : MonoBehaviour {
	public Factions faction;
	public bool inBattle;
}




/*
Needed systems 11-28-18

CombtantSpawner

*/