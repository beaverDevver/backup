using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public class RosterSystem : ComponentSystem {

	public struct PlayerData {
		public readonly int Length;
		public EntityArray entity;
		public ComponentArray<PartyRoster> roster;
	}

	public struct AllyData {
		public readonly int Length;
		public EntityArray entity;
		public ComponentArray<PartyMember> member;
	}

	[Inject] private PlayerData playerData_;
	[Inject] private AllyData allyData_;




	public void CreateParty (PartyRoster roster) {
		var settings = Bootstrap.settings_;

		var ally = Object.Instantiate(settings.allyPrefab_);
		AddAllyToParty(roster, ally, AllyType.Red);

		ally = Object.Instantiate(settings.allyPrefab_);
		AddAllyToParty(roster, ally, AllyType.Blue);

		ally = Object.Instantiate(settings.allyPrefab_);
		AddAllyToParty(roster, ally, AllyType.Green);

		ally = Object.Instantiate(settings.allyPrefab_);
		AddAllyToParty(roster, ally, AllyType.Yellow);

	}

	public void AddAllyToParty (PartyRoster roster, GameObject ally, AllyType type) {

		var command = ally.GetComponent<Command>();
		command.owner = ally;
		command.newCommand = false;

		var combatant = ally.GetComponent<Combatant>();
		combatant.faction = Factions.Ally;
		combatant.inBattle = false;

		var member = ally.GetComponent<PartyMember>();
		member.isActive = false;
		member.isDeploying = false;
		member.isRetrieving = false;
		member.deployOrder = -1;
		member.type = type;

		switch(type) {
		case AllyType.Red:
			roster.red = ally;
			break;
		case AllyType.Blue:
			roster.blue = ally;
			break;
		case AllyType.Green:
			roster.green = ally;
			break;
		case AllyType.Yellow:
			roster.yellow = ally;
			break;
		}
	}

	public void RemoveAllyFromParty (GameObject ally) {

	}

	protected override void OnUpdate () {
		for(int i = 0; i < allyData_.Length; ++i) {
			if(allyData_.member[i].isDeploying) {
				//check deploy order to see if it has been set
				if(allyData_.member[i].deployOrder < 0) {
					for(int j = 0; j < playerData_.Length; ++j) { //need a way to sync allies party members with corresponding party rosters
						playerData_.roster[j].numDeployed += 1;
						allyData_.member[i].deployOrder = playerData_.roster[j].numDeployed;
						break;
					}
				}
			} else if (allyData_.member[i].isRetrieving) {
				if(allyData_.member[i].deployOrder > 0) {
					int emptyIndex = allyData_.member[i].deployOrder;
					for(int j = 0; j < playerData_.Length; ++j) { 
						playerData_.roster[j].numDeployed -= 1;
						allyData_.member[i].deployOrder = -1;
					}
					//adjust deploy order of allies past the one removed
					for (int k = 0; k < allyData_.Length; ++k) {
						if(i == k) {
							continue;
						} else {
							if(allyData_.member[k].deployOrder > emptyIndex) {
								allyData_.member[k].deployOrder -= 1;
							}
						}
					}
				}
			}
		}
	}




}
	

