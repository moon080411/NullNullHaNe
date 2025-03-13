using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Weapon/Player")]
public class PlayerWeapon : AgentWeapon
{
    public float attackCoolTime1 = 2.4f;
    public int attackDamage1 = 80;
    public float attackCoolTime2 = 3f;
    public int attackDamage2 = 90;
    public float attackCoolTime3 = 3.5f;
    public int attackDamage3 = 100;
    public float attackCoolTime4 = 4.8f;
    public int attackDamage4 = 110;
    public float attackCoolTime5 = 6.3f;
    public int attackDamage5 = 170;
}
