using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
/*
public class Attribute : MonoBehaviour{
	public float currentValue;
	public float baseValue;

}

public class ElementalAttribute : MonoBehaviour {
	public Attribute effect;
	public Attribute resistance;
}
*/
public class Stats : MonoBehaviour
{
	public float2 health;
	public float2 damage;
	public float2 defense;
	public float2 speed;

	public float2 greenEffect;
	public float2 greenResistance;
	public float2 redEffect;
	public float2 redResistance;
	public float2 blueEffect;
	public float2 blueResistance;
	public float2 yellowEffect;
	public float2 yellowResistance;
}
