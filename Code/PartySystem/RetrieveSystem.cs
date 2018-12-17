using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class RetrieveSystem : ComponentSystem
{
	public struct AllyData {
		public readonly int Length;
		public EntityArray entity;
		public ComponentArray<Combatant> combatant;
		public ComponentArray<PartyMember> member;
		public ComponentArray<Command> command;
	}
		
	[Inject] private AllyData data_;

	protected override void OnUpdate () {
		if(data_.Length == 0) {
			return;
		}

		for(int i =0; i < data_.Length; ++i) {
			if(data_.command[i].newCommand ) {
				if(data_.command[i].type == CommandType.Retrieve) {
					if(data_.member[i].isRetrieving == false && data_.member[i].isDeploying == false && data_.member[i].isActive == true) {
						data_.command[i].newCommand = false;
						StartRetrieving(i);
					}
				}
			}
			if(data_.member[i].isRetrieving) {
				Debug.Log("Handlingretrieving logic");
				if(data_.member[i].transitionTimer < 0.0f) {
					FinishRetrieving(i);
				} else {
					data_.member[i].transitionTimer -= Time.deltaTime;
				}
			}
		}
	}

	private void StartRetrieving (int index) {
		Debug.Log("RETRIEVing");
		data_.member[index].isRetrieving = true;
		data_.member[index].transitionTimer = 1.0f;
	}


	private void FinishRetrieving (int index) {
		Debug.Log("RETRIEVed");
		data_.member[index].isRetrieving = false;
		data_.member[index].isActive = false;
		data_.combatant[index].inBattle = false;

	}
}
