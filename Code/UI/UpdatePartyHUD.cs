using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Entities;

[AlwaysUpdateSystem]
public class UpdatePartyHUD : ComponentSystem
{

	public struct PlayerData {
		public readonly int Length;
		public EntityArray entity;
		public ComponentArray<Input> input;
		public ComponentArray<PartyRoster> roster;
	}

	public struct PartyData {
		public readonly int Length;
		public EntityArray entity;
		public ComponentArray<PartyMember> member;
	}

	[Inject] private PlayerData player_;
	[Inject] private PartyData party_;

	private Button deployRed_;
	private Button deployBlue_;
	private Button deployGreen_;
	private Button deployYellow_;

	public void SetupPartyHUD () {
		deployRed_ = GameObject.Find("DeployRed").GetComponent<Button>();
		deployRed_.onClick.AddListener(DeployRed);

		deployBlue_ = GameObject.Find("DeployBlue").GetComponent<Button>();
		deployBlue_.onClick.AddListener(DeployBlue);

		deployGreen_ = GameObject.Find("DeployGreen").GetComponent<Button>();
		deployGreen_.onClick.AddListener(DeployGreen);

		deployYellow_ = GameObject.Find("DeployYellow").GetComponent<Button>();
		deployYellow_.onClick.AddListener(DeployYellow);
	}

	protected override void OnUpdate () {
		//just checking here
		for (int i = 0; i < party_.Length; ++i) {
//			Debug.Log(party_.member[i].deployOrder);
		}
	}
	private void DeployAlly (AllyType type) {
		for(int i =0; i < player_.Length; ++i) {
			player_.input[i].newCommand = true;
			player_.input[i].commandType = CommandType.Deploy;
			player_.input[i].allyType = type;

			switch(type) {
			case AllyType.Red:
				player_.input[i].selectedAlly = player_.roster[i].selectedAlly = player_.roster[i].red;
				break;
			case AllyType.Blue:
				player_.input[i].selectedAlly = player_.roster[i].selectedAlly = player_.roster[i].blue;
				break;
			case AllyType.Green:
				player_.input[i].selectedAlly = player_.roster[i].selectedAlly = player_.roster[i].green;
				break;
			case AllyType.Yellow:
				player_.input[i].selectedAlly = player_.roster[i].selectedAlly = player_.roster[i].yellow;
				break;
			}
		}
	}

	public void DeployRed () {
		DeployAlly(AllyType.Red);
	}
	public void DeployBlue () {
		DeployAlly(AllyType.Blue);
	}
	public void DeployGreen () {
		DeployAlly(AllyType.Green);
	}	
	public void DeployYellow () {
		DeployAlly(AllyType.Yellow );
	}
}


