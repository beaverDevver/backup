using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public class CommandCreator : ComponentSystem {
	public struct PlayerData {
		public readonly int Length;
		public ComponentArray<Input> input;
		public ComponentArray<PartyRoster> roster;

	}

	public struct AllyData {
		public readonly int Length;
		public ComponentArray<Command> command;
		public ComponentArray<PartyMember> member;
	}
	[Inject] private PlayerData playerData_;
	[Inject] private AllyData allyData_;

	protected override void OnUpdate () {
		for (int i = 0; i < playerData_.Length; ++i) {
			if(playerData_.input[i].newCommand == true) {
				CreateCommand(i, playerData_.input[i].commandType );
				playerData_.input[i].newCommand = false;
			}
		}
	}

	private void CreateCommand(int playerIndex, CommandType commandType) {
		
		//check flags to make ally is valid to receive command
		//if not valid, cancel command and tell player to try again
		//preferably with "wuh wuh" noise
		for(int i = 0; i < allyData_.Length; ++i) {
			switch(commandType) {
			case CommandType.Deploy:
				
					if(playerData_.input[playerIndex].selectedAlly == allyData_.command[i].owner) {
						if(allyData_.member[i].isDeploying || allyData_.member[i].isRetrieving || allyData_.member[i].isActive) {
							Debug.Log("Deploy command not issued");
							return;
						} else {
							allyData_.command[i].newCommand = true;
							allyData_.command[i].type = commandType;
							allyData_.command[i].target = playerData_.input[playerIndex].target;
						}
					}



				break;
			case CommandType.Retrieve:
				if(playerData_.input[playerIndex].allyDeployOrder == allyData_.member[i].deployOrder) {
					if(allyData_.member[i].isDeploying || allyData_.member[i].isRetrieving || allyData_.member[i].isActive == false) {
						Debug.Log("Retrieve command not issued");
						return;
					} else {
						allyData_.command[i].newCommand = true;
						allyData_.command[i].type = commandType;

					}
				}
				break;
			case CommandType.Action:
				/*
				if(playerData_.input[playerIndex].allyDeployOrder == allyData_.member.deployOrder) {
					if(allyData_.member[allyIndex].isDeploying || allyData_.member[allyIndex].isRetrieving || allyData_.member[allyIndex].isActive == false) {
						Debug.Log("Action command not issued");
						return;
					} else {
						allyData_.command[i].newCommand = true;
						allyData_.command[i].type = commandType;
					}
				}*/
				break;
			}
		}

	}


}
	