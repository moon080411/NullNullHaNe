using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ElementType
{
    Normal,
    Fire,
    Water,
    Wind,
    Lightning,
    Special
}
[CreateAssetMenu(menuName = "SO/Weapon/Agent")]
public class AgentWeapon : ScriptableObject
{
    public int damage;
    public float attackCoolTime;
    public ElementType elementType;
}
