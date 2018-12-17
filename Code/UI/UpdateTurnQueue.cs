using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class UpdateTurnQueue : ComponentSystem
{

	public struct PartyData {
		public readonly int Length;
		public EntityArray entity;
		public ComponentArray<PartyMember> party;
		public ComponentArray<Turn> turn;
	}

	[Inject] private PartyData partyData_;

	public void SetupTurnQueue () {

	}

	protected override void OnUpdate () {

	}
}
