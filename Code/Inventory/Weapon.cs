using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public enum WeaponRole {Melee, Range, Spell, Power};

public enum WeaponType {BasicSword, Spear, Axe, Club, Mace, 
						BasicBlaster, Bow, Shotgun, Carbine, SniperRifle, MachineGun, Rifle, 
						BasicSpell, Bomb, Barrage, GoundSlam, GravBall, 
						BasicPowerSword, Claymore, BattleAxe, Hook};


public class Weapon : MonoBehaviour
{
	public WeaponRole role; 
	public WeaponType type;
	public GameObject weaponObject;
}
