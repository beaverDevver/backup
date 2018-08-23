	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHero : MonoBehaviour {
	public Text nameUI_;
	public Text healthUI_;
	public Text attackUI_;
	public Text defenseUI_;
	public Text speedUI_;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowHero (AllyInfo info) {
		/*nameUI_.text = info.GetName ();

		Stats stats = info.gameObject.GetComponent<Stats> ();
		if (stats) {
			attackUI_.text = stats.GetAttack ().ToString ();
			defenseUI_.text = stats.GetDefense ().ToString ();
			speedUI_.text = stats.GetSpeed ().ToString ();
		}

		Health health = info.gameObject.GetComponent<Health> ();
		if (health) {
			healthUI_.text = health.GetHealth ().ToString () + "/" + health.GetMaxHealth ().ToString ();
		}
*/

	}
}
