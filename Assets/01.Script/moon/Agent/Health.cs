using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action OnDamaged;
    public event Action OnDie;
    int maxHelth;
    int health;

    private void Awake()
    {
        health = maxHelth;
    }
    public void SetMaxHelth(int maxHelth)
    {
        this.maxHelth = maxHelth;
    }
    public void SetHealth(int health)
    {
        this.health = health;
    }
    public int GetMaxHealth()
    {
        return maxHelth;
    }
    public int GetHealth()
    {
        return health;
    }
    public float GetHealthPercent()
    {
        return (float)maxHelth / health;
    }
    public void Damaged(int damage)
    {
        health -= damage;
        if (health > 0)
        {
            OnDamaged?.Invoke();
        }
        else
        {
            health = 0;
            OnDie?.Invoke();
        }
    }
}
