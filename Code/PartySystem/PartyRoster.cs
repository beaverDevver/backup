using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public enum AllyType {Red, Blue, Green, Yellow}

public class PartyRoster : MonoBehaviour
{
	public int numOfAllies;
	public int numDeployed;
	public GameObject selectedAlly; //for deployment
	public GameObject receivingAlly; //receives command

	public GameObject red;
	public GameObject blue;
	public GameObject green;
	public GameObject yellow;
}
/*
Adding weapon system


*/