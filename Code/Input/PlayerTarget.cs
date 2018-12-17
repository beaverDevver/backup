using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType {Ally, Enemy/*, NPC, Object, Puzzle, Terrain*/};

public class PlayerTarget : MonoBehaviour
{
	public Combatant target;
	public TargetType type;
}
