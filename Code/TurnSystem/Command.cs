using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public enum CommandType {Action, Move, Deploy, Retrieve};

public class Command : MonoBehaviour {
	public bool newCommand;
	public CommandType type;
	public GameObject owner;
	public GameObject target;
}
