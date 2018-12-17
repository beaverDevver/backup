using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.UI; 
using Unity.Mathematics;

public class UpdateStatSheet : ComponentSystem
{

	public struct EnemyData {
		public readonly int Length;
		public EntityArray entity;
		public ComponentArray<Combatant> combatant;
		public ComponentArray<Stats> stats;
		public ComponentArray<Enemy> enemy;
	}

	public struct AllyData {
		public readonly int Length;
		public EntityArray entity;
		public ComponentArray<Combatant> combatant;
		public ComponentArray<Stats> stats;
		public ComponentArray<PartyMember> member;
	}

	//for button presses, Retrieve and select ally input
	public struct InputData {
		public readonly int Length;
		public ComponentArray<Input> input;
	}
		
	[Inject] private EnemyData enemyData_;
	[Inject] private AllyData allyData_;

	//for button presses, Retrieve and select ally input
	[Inject] private InputData inputData_;


	private List<GameObject> allyStatSheets_;
	private List<GameObject> enemyStatSheets_;

	//for button presses, Retrieve and select ally input
	private List<bool> retrieveRequest_;
	private List<bool> selectRequest_;

	public void SetupStatSheets () {
		allyStatSheets_ = new List<GameObject>();
		enemyStatSheets_ = new List<GameObject>();
		//for button presses, Retrieve and select ally input
		retrieveRequest_ = new List<bool> (4);
		selectRequest_ = new List<bool>(4);

		Button button;
		for(int i = 0; i < 4; i++) {
			//create new statsheet
			var newStatSheet = Object.Instantiate(Bootstrap.settings_.allyStatSheetPrefab_);
			//add as child to UI object, set position
			var obj = GameObject.Find("AllyStatSheets");
			float3 pos = obj.transform.position;
			newStatSheet.transform.parent = obj.transform;
			newStatSheet.transform.position = new float3(pos.x + i * 250, pos.y, pos.z);

			//for button presses, Retrieve and select ally input
			selectRequest_.Add(false);
			retrieveRequest_.Add(false);

			obj = newStatSheet.transform.Find("SelectButton").gameObject;
			button = obj.GetComponent<Button>();
			switch(i) {
			case 0:
				button.onClick.AddListener(() =>HandleSelectClick(0));
				break;
			case 1:
				button.onClick.AddListener(() =>HandleSelectClick(1));
				break;
			case 2:
				button.onClick.AddListener(() =>HandleSelectClick(2));
				break;
			case 3:
				button.onClick.AddListener(() =>HandleSelectClick(3));
				break;
			}
			obj = newStatSheet.transform.Find("RetrieveButton").gameObject;
			button = obj.GetComponent<Button>();
			switch(i) {
			case 0:
				button.onClick.AddListener(() =>HandleRetrieveClick(0));
				break;
			case 1:
				button.onClick.AddListener(() =>HandleRetrieveClick(1));
				break;
			case 2:
				button.onClick.AddListener(() =>HandleRetrieveClick(2));
				break;
			case 3:
				button.onClick.AddListener(() =>HandleRetrieveClick(3));
				break;
			}

			//add allystat sheet
			allyStatSheets_.Add(newStatSheet);
		}
	}

	protected override void OnUpdate () {
		int numInactive = 0;
		for(int i= 0; i < allyData_.Length; ++i) {
			//SetStatSheet(statSheet1_, allyData_.stats[i]);
			int index = allyData_.member[i].deployOrder - 1;
			if(allyData_.member[i].isActive && allyData_.member[i].isRetrieving == false) {
				allyStatSheets_[index].SetActive(true);
				SetStatSheet(allyStatSheets_[index], allyData_.stats[i], allyData_.member[i].type);
			} else {
				numInactive += 1;
			}
		}
		if(numInactive > 0) {
			for(int i = 0; i < numInactive; ++i) {
				allyStatSheets_[3 - i].SetActive(false);
			}
		}
		
		
		for(int i = 0; i < inputData_.Length; ++i) {
			for(int j = 0; j < 4; ++j) {
				if(selectRequest_[j]) {
					inputData_.input[i].newCommand = true;
					inputData_.input[i].commandType = CommandType.Action;
					inputData_.input[i].allyDeployOrder = j + 1;
					selectRequest_[j] = false;
				}
				if(retrieveRequest_[j]) {
					inputData_.input[i].newCommand = true;
					inputData_.input[i].commandType = CommandType.Retrieve;
					inputData_.input[i].allyDeployOrder = j + 1;
					retrieveRequest_[j] = false;
				}
			}
		}

	}


	public void HandleRetrieveClick(int index) {
		retrieveRequest_[index] = true;
	}

	public void HandleSelectClick(int index) {
		selectRequest_[index] = true;
	}


	//function for writing stats to the UI object
	private void SetStatSheet (GameObject statSheet, Stats stats, AllyType type) {
		var obj = statSheet.transform.Find("Stats/AttackStat/Value");
		var text = obj.gameObject.GetComponent<Text>();
		text.text = stats.damage.x.ToString();

		obj = statSheet.transform.Find("Stats/DefenseStat/Value");
		text = obj.gameObject.GetComponent<Text>();
		text.text = stats.defense.x.ToString();

		obj = statSheet.transform.Find("Stats/SpeedStat/Value");
		text = obj.gameObject.GetComponent<Text>();
		text.text = stats.speed.x.ToString();

		obj = statSheet.transform.Find("Stats/LifeStat/Value");
		text = obj.gameObject.GetComponent<Text>();
		text.text = stats.health.x.ToString();

		obj = statSheet.transform.Find("EffectStats/AttackEffect/ResistanceValue");
		text = obj.gameObject.GetComponent<Text>();
		text.text = stats.redEffect.x.ToString();
		obj = statSheet.transform.Find("EffectStats/AttackEffect/DamageValue");
		text = obj.gameObject.GetComponent<Text>();
		text.text = stats.redResistance.x.ToString();

		obj = statSheet.transform.Find("EffectStats/DefenseEffect/ResistanceValue");
		text = obj.gameObject.GetComponent<Text>();
		text.text = stats.blueEffect.x.ToString();
		obj = statSheet.transform.Find("EffectStats/DefenseEffect/DamageValue");
		text = obj.gameObject.GetComponent<Text>();
		text.text = stats.blueResistance.x.ToString();

		obj = statSheet.transform.Find("EffectStats/SpeedEffect/ResistanceValue");
		text = obj.gameObject.GetComponent<Text>();
		text.text = stats.yellowEffect.x.ToString();
		obj = statSheet.transform.Find("EffectStats/SpeedEffect/DamageValue");
		text = obj.gameObject.GetComponent<Text>();
		text.text = stats.yellowResistance.x.ToString();

		obj = statSheet.transform.Find("EffectStats/LifeEffect/ResistanceValue");
		text = obj.gameObject.GetComponent<Text>();
		text.text = stats.greenEffect.x.ToString();
		obj = statSheet.transform.Find("EffectStats/LifeEffect/DamageValue");
		text = obj.gameObject.GetComponent<Text>();
		text.text = stats.greenResistance.x.ToString();

		obj = statSheet.transform.Find("Name");
		text = obj.gameObject.GetComponent<Text>();
		switch(type) {
		case AllyType.Red:
			text.text = "Red";
			break;
		case AllyType.Blue:
			text.text = "Blue";
			break;
		case AllyType.Green:
			text.text = "Green";
			break;
		case AllyType.Yellow:
			text.text = "Yellow";
			break;
		}
	}
}

