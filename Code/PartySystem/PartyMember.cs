using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class PartyMember : MonoBehaviour
{
		//variables used for deploying and retrieving
	public bool isActive;
	public bool isDeploying;
	public bool isRetrieving;
	public float transitionTimer;
		//identifier
	public AllyType type;
		//determine which weapon is equipped
	public int deployOrder;
	public WeaponType weapon_;
}
