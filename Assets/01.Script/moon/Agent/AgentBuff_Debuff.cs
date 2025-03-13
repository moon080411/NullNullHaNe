using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBuff_Debuff : MonoBehaviour
{
    private Agent _agent;
    public float fireKeepTimer = 0;
    private float fireAttackTimer = 1;
    public float waterKeepTimer = 0;
    private float waterHealingTimer = 2;
    private void Awake()
    {
        _agent = GetComponent<Agent>();
    }
    private void Update()
    {
        if(fireKeepTimer > 0)
        {
            fireKeepTimer -= Time.deltaTime;
            fireAttackTimer -= Time.deltaTime;
            if(fireAttackTimer <= 0)
            {
                _agent.GetHit(15, true, ElementType.Fire, _agent);
                fireAttackTimer = 1;
            }
        }
        if(waterKeepTimer > 0)
        {
            waterHealingTimer -= Time.deltaTime;
            waterKeepTimer -= Time.deltaTime;
            if(waterHealingTimer <= 0)
            {
                _agent.HealingPercent(5);
                waterHealingTimer = 2;
            }
        }
    }
}