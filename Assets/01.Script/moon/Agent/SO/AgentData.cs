using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AgentData : ScriptableObject
{
    public int maxHp;
    public int damage;
    public float moveSpeed;
    public float attackCoolTime;
    public float hitInvincibilityTime;
}
