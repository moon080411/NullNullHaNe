using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
    [SerializeField] private float normalCooltime;
    public float normalTimer { get; private set; } = 0;

    [SerializeField] private float fireCooltime;
    [SerializeField] private Vector2 fireBoxSize;
    public float fireTimer { get; private set; } = 0;

    [SerializeField] private float waterCooltime;
    public float waterTimer { get; private set; } = 0;

    [SerializeField] private float windCooltime;
    public float windTimer { get; private set; } = 0;

    [SerializeField] private float lightningCooltime;
    public float lightningTimer { get; private set; } = 0;

    [SerializeField] private AgentBuff_Debuff myBuffDebuff;

    [SerializeField] private Transform player;
    public void UseSkill(ElementType element)
    {
        switch (element)
        {
            case ElementType.Normal:
                NormalSkill();
                break;
            case ElementType.Fire:
                FireSkill();
                break;
            case ElementType.Water:
                WaterSkill();
                break;
            case ElementType.Wind:
                WindSkill();
                break;
            case ElementType.Lightning:
                LightningSkill();
                break;
            default:
                NormalSkill();
                break;
        }
    }
    private void NormalSkill()
    {

    }

    private void FireSkill()
    {
        if(fireTimer <= 0)
        {   
            Collider2D[] colliders = Physics2D.OverlapBoxAll(player.position, fireBoxSize, 0);
            foreach(Collider2D collider in colliders)
            {
                AgentBuff_Debuff debuff = collider.GetComponent<AgentBuff_Debuff>();
                debuff.fireKeepTimer = 3.01f;
            }
            fireTimer = fireCooltime;
        }
    }

    private void WaterSkill()
    {
        if(waterTimer <= 0)
        {
            myBuffDebuff.waterKeepTimer = 4.01f;
            waterTimer = waterCooltime;
        }
    }

    private void WindSkill()
    {

    }

    private void LightningSkill()
    {

    }

    private void Update()
    {
        if(normalTimer > 0)
        {
            normalTimer -= Time.deltaTime;
        }
        if(fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
        if(waterTimer > 0)
        {
            waterTimer -= Time.deltaTime;
        }
        if(windTimer > 0)
        {
            windTimer -= Time.deltaTime;
        }
        if (lightningCooltime > 0)
        {
            lightningCooltime -= Time.deltaTime;
        }
    }
}
