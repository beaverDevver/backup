using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public sealed class Bootstrap 
{
	public static Settings settings_;

	public static void NewGame () {
		var player = Object.Instantiate(settings_.playerPrefab_);
		var roster = player.GetComponent<PartyRoster>();
		World.Active.GetOrCreateManager<RosterSystem>().CreateParty(roster);
		Debug.Log("Created party");
		Debug.Log(roster.red);
		Debug.Log(roster.blue);
		Debug.Log(roster.green);
		Debug.Log(roster.yellow);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	public static void InitializeAfterSceneLoad () {
		
		var settingsObj = GameObject.Find("Settings");
		if(settingsObj == null) {
			SceneManager.sceneLoaded += OnSceneLoaded;
			return;
		}

		InitializeWithScene();

	}


	private static void OnSceneLoaded (Scene arg0, LoadSceneMode arg1) {
		InitializeWithScene();
	}

	public static void InitializeWithScene () {
		var settingsObj = GameObject.Find("Settings");
		settings_ = settingsObj?.GetComponent<Settings>();
		if(settings_ == null) {
			return;
		}

		World.Active.GetOrCreateManager<UpdatePartyHUD>().SetupPartyHUD();
		World.Active.GetOrCreateManager<UpdateStatSheet>().SetupStatSheets();
		World.Active.GetOrCreateManager<UpdateTurnQueue>().SetupTurnQueue();
		NewGame();
	} 
}
