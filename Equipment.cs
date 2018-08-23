using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Equipment : MonoBehaviour {
	public Weapon standardWeapon_;
	public Weapon specialWeapon_;


	public class EquipmentComponent : ComponentDataWrapper<Equipment>();
}
/*
	// Use this for initialization
	void Start () {
		
	}

	public void OnEnable () {

	}

	public void OnDisable () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EquipWeapon (Weapon newWeapon, bool isStandard = true) {
		if (isStandard) {
			EquipStandardWeapon (newWeapon);
		} else {
			EquipSpecialWeapon (newWeapon);
		}
	}

	public void EquipStandardWeapon (Weapon newStandard) {
		if (standardWeapon_) {
			UnequipStandardWeapon ();
		}
		standardWeapon_ = newStandard;
		//send event
	}

	public void EquipSpecialWeapon (Weapon newSpecial) {
		if (specialWeapon_) {
			UnequipSpecialWeapon ();
		}
		specialWeapon_ = newSpecial;
		//send event
	}

	public Weapon GetEquippedWeapon (bool getStandard = true) {
		if (getStandard) {
			return GetStandardWeapon();
		} else {
			return GetSpecialWeapon ();
		}
	}

	public Weapon GetStandardWeapon () {
		return standardWeapon_;
	}

	public Weapon GetSpecialWeapon () {
		return specialWeapon_;
	}
		//unequip can make weapons disappear 1/12
	public void UnequipWeapon (bool isStandard = true) {
		if (isStandard) {
			UnequipStandardWeapon ();
		} else {
			UnequipSpecialWeapon ();
		}
	}

	public void UnequipStandardWeapon () {
		if (standardWeapon_) {
			//send event
		}
		standardWeapon_ = null;
	}

	public void UnequipSpecialWeapon () {
		if (specialWeapon_) {
			//send event
		}
		specialWeapon_ = null;
	}

	public bool HasWeaponEquipped () { 
		return false;
	}

}*/
	
