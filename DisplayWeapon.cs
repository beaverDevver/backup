using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWeapon : MonoBehaviour {
	public Text nameUI_;
	public Text damageUI_;
	public Text defenseUI_;
	public Text weightUI_;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowWeapon (Weapon weapon) {
		nameUI_.text = weapon.GetWeaponName ();
		damageUI_.text = weapon.GetDamage ().ToString ();
		defenseUI_.text = weapon.GetDefense ().ToString ();
		
	}
}
