using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.UI;

public class InputSystem : ComponentSystem
{
	public struct PlayerInput {
		public readonly int Length;
		public EntityArray entity;
		public ComponentArray<Input> input;
	}

	[Inject] private PlayerInput input_;

	private Button deployRed_;
	private Button deployBlue_;
	private Button deployGreen_;
	private Button deployYellow_;

	private List<Button> retrieveButtons_;

	private List<Button> targetButton_;

	protected override void OnUpdate() {

	}
}

//		public Input input_;
/*	public PartyRoster roster_;




	public List<Button> targetEnemy_;*/


	// Start is called before the first frame update
	//  void Start()
	// {
	/*input_ = gameObject.GetComponent<Input>();
		if(input_ == null) {
			Debug.Log("Could not find Input componenet");
		}

		roster_ = gameObject.GetComponent<PartyRoster>();
		if(roster_ == null) {
			Debug.Log("Could not find PartRoster component");
		}

		input_.newCommand_ = false;

		GetAndAssignButtons();*/

	//  }


/*
	private void DeployAlly (AllyType type) {
		Debug.Log("Deploy called");
		input_.selectedAlly_ = type;
		input_.command_ = CommandType.Deploy;
		input_.newCommand_ = true;
	}

	private void RetrieveAlly (AllyType type) {
		input_.selectedAlly_ = type;
		input_.command_ = CommandType.Retrieve;
		input_.newCommand_ = true;
	}

	private void CreateTargetCommand (AllyType ally, Combatant target) {
		input_.selectedAlly_ = ally;
		input_.target_ = target;
		input_.command_ = CommandType.Action;
		input_.newCommand_ = true;
	}
	*/
/***************************************************************************************************************/
//deploy functions
/*public void DeployRed () {
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
	}*/

/***************************************************************************************************************/
//retrieve functions
/*public void RetrieveFirst () {
		RetrieveAlly(roster_.firstDeployed_);
	}
	public void RetrieveSecond () {
		RetrieveAlly(roster_.secondDeployed_);

	}
	public void RetrieveThird () {
		RetrieveAlly(roster_.thirdDeployed_);

	}	
	public void RetrieveFourth () {
		RetrieveAlly(roster_.fourthDeployed_);

	}*/

/***************************************************************************************************************/
//target functions
/*public void TargetFirst () {
		FindTargettedAlly(roster_.firstDeployed_);
	}
	public void TargetSecond () {
		FindTargettedAlly(roster_.secondDeployed_);
	}
	public void TargetThird () {
		FindTargettedAlly(roster_.thirdDeployed_);
	}	
	public void TargetFourth () {
		FindTargettedAlly(roster_.fourthDeployed_);
	}

	private void FindTargettedAlly (AllyType type) {
		switch (type) {
		case AllyType.Red:
			CreateTargetCommand(roster_.receivingAlly_, roster_.red_);
			break;
		case AllyType.Blue:
			CreateTargetCommand(roster_.receivingAlly_, roster_.blue_);
			break;
		case AllyType.Green:
			CreateTargetCommand(roster_.receivingAlly_, roster_.green_);
			break;
		case AllyType.Yellow:
			CreateTargetCommand(roster_.receivingAlly_, roster_.yellow_);
			break;
		}
	}

	public void TargetEnemy () {

	}



	private void GetAndAssignButtons () {

		deployRed_ = GameObject.Find("DeployRed").GetComponent<Button>();
		deployRed_.onClick.AddListener(DeployRed);

		deployBlue_ = GameObject.Find("DeployBlue").GetComponent<Button>();
		deployBlue_.onClick.AddListener(DeployBlue);

		deployGreen_ = GameObject.Find("DeployGreen").GetComponent<Button>();
		deployGreen_.onClick.AddListener(DeployGreen);

		deployYellow_ = GameObject.Find("DeployYellow").GetComponent<Button>();
		deployYellow_.onClick.AddListener(DeployYellow);


		retrieve1st_ = GameObject.Find("Retrieve1").GetComponent<Button>();
		retrieve1st_.onClick.AddListener(RetrieveFirst);

		retrieve2nd_ = GameObject.Find("Retrieve2").GetComponent<Button>();
		retrieve2nd_.onClick.AddListener(RetrieveSecond);

		retrieve3rd_ = GameObject.Find("Retrieve3").GetComponent<Button>();
		retrieve3rd_.onClick.AddListener(RetrieveThird);

		retrieve4th_ = GameObject.Find("Retrieve4").GetComponent<Button>();
		retrieve4th_.onClick.AddListener(RetrieveFourth);


		target1st_ = GameObject.Find("Select1").GetComponent<Button>();
		target1st_.onClick.AddListener(TargetFirst);

		target2nd_ = GameObject.Find("Select2").GetComponent<Button>();
		target2nd_.onClick.AddListener(TargetSecond);

		target3rd_ = GameObject.Find("Select3").GetComponent<Button>();
		target3rd_.onClick.AddListener(TargetThird);

		target4th_ = GameObject.Find("Select4").GetComponent<Button>();
		target4th_.onClick.AddListener(TargetFourth);
	}

}*/
