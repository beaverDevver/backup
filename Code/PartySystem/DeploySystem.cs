using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class DeploySystem : ComponentSystem
{
	public struct AllyData {
		public readonly int Length;
		public EntityArray entity;
		public ComponentArray<Combatant> combatant;
		public ComponentArray<PartyMember> member;
		public ComponentArray<Command> command;
	}

	public struct PartyData {
		public readonly int Length;
		public EntityArray entity;
		public ComponentArray<PartyRoster> roster;
	}

	[Inject] private AllyData data_;
	[Inject] private PartyData party_;//to set deloy order and number deployed

	protected override void OnUpdate () {
		if(data_.Length == 0) {
			return;
		}

		for(int i =0; i < data_.Length; ++i) {
			if(data_.command[i].newCommand ) {
				if(data_.command[i].type == CommandType.Deploy) {
					if(data_.member[i].isRetrieving == false && data_.member[i].isActive == false && data_.member[i].isDeploying == false){
						data_.command[i].newCommand = false;
						StartDeploying(i);
					}
				}
			}
			if(data_.member[i].isDeploying) {
				if(data_.member[i].transitionTimer < 0.0f) {
					FinishDeploying(i);
				} else {
					data_.member[i].transitionTimer -= Time.deltaTime;
				}
			}
		}
	}

	private void StartDeploying (int index) {
		Debug.Log("DEPLOYing");
		data_.member[index].isDeploying = true;
		data_.member[index].transitionTimer = 1.0f;
	}

	private void FinishDeploying (int index) {
		Debug.Log("DEPLOYed");
		data_.member[index].isDeploying = false;
		data_.member[index].isActive = true;
		data_.combatant[index].inBattle = true;


	}
}
