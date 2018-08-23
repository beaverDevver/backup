using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType {Weapon, Shield, Teleporter, Bomb};
public enum WeaponType {Axe, Spear, Sword, Mace, Club, Bow, Broadsword, Sniper, Shotgun, Rifle};


[Serializable]
public struct Weapon : IComponentData{
	public float damage_;
	public float range_;
	public float defense_;
	public WeaponType type_;
	public float attackInterval_;
	public string name_;

	public int value_;
	public string owner_;
	public Sprite attackIcon_;

	public class WeaponComponent : ComponentDataWrapper<Weapon> {}
}
//	[SerializeField] private RPGCharacterAnims.WeaponAnimationType weaponModel_;

	// Use this for initialization
/*	void Start () {
		
	}

	void OnEnable () {

	}

	void OnDisable () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void SetOwner (string ownerName) {
		owner_ = ownerName;
	}
		
	public float GetDamage () {
		return damage_;
	}

	public float GetRange () {
		return range_;
	}

	public float GetDefense () {
		return defense_;
	}

	public WeaponType GetWeaponType () {
		return type_;
	}

	public float GetAttackInterval () {
		return attackInterval_;
	}

	public string GetWeaponName () {
		return name_;
	}

	public int GetValue () {
		return value_;
	}

	public string GetOwnerName () {
		return owner_;
	}

	public Sprite GetAttackIcon() {
		return attackIcon_;
	}

//	public RPGCharacterAnims.WeaponAnimationType GetWeaponModel () {
//		return weaponModel_;
//	}
}

public class EquipWeaponEventData : EventData  {
	public Weapon equippedWeapon_;

	public EquipWeaponEventData (Weapon weapon ) {
		equippedWeapon_ = weapon;
	}

}*/
