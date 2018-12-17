using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class Input : MonoBehaviour
{
	public bool newCommand;

	public GameObject target;
	public GameObject selectedAlly;
	public AllyType allyType;
	public int allyDeployOrder;
	public CommandType commandType;
}
