using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/Agent")]
public class AgentWeapon : ScriptableObject
{
    public int damage;
    public float attackCoolTime;
}
