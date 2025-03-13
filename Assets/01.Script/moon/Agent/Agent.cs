using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle,
    Move,
    Attack,
    Jump,
    Fall
}
public abstract class Agent : MonoBehaviour , IHittable
{
    #region component region
    public Rigidbody2D RbCompo { get; protected set; }
    public AgentAnimation AniCompo { get; protected set; }
    public GroundChecker GroundCheckCompo { get; protected set; }
    public AgentData dataCompo;
    public AgentWeapon weaponCompo;
    public Health HealthCompo { get; protected set; }
    public AgentFlip FilpCompo { get; protected set; }
    #endregion
    protected Dictionary<StateType, State> StateEnum = new Dictionary<StateType, State>();
    protected Dictionary<PlayerStateType, State> PlayerStateEnum = new Dictionary<PlayerStateType, State>();

    public Transform myTra;

    private float timer;

    private float invincibilityTimer;

    private bool invincibility = false;

    [HideInInspector] private State _currentState;

    public float speed;

    protected virtual void Awake()
    {
        RbCompo = GetComponent<Rigidbody2D>();
        HealthCompo = GetComponent<Health>();
        AniCompo = GetComponentInChildren<AgentAnimation>();
        GroundCheckCompo = GetComponentInChildren<GroundChecker>();
        FilpCompo = GetComponentInChildren<AgentFlip>();
        myTra = transform;
        timer = weaponCompo.attackCoolTime;
        speed = dataCompo.moveSpeed;
        InitializeState();
    }
    public void ChangeWeapon(AgentWeapon weapon)
    {
        weaponCompo = weapon;
    }
    protected virtual void Start()
    {
        TransitionState(StateType.Idle);
    }

    //public void StopRotationAttack()
    //{
    //    if(_currentState.GetType() == typeof(PlayerRotationState))
    //    {
    //        TransitionState(StateType.Idle);
    //    }
    //}

    protected virtual void SwitchAttack()
    {
        if(timer <= 0)
        {
            TransitionState(StateType.Attack);
            timer = weaponCompo.attackCoolTime;
        }
    }

    public abstract void InitializeState();
    public void TransitionState(StateType desireState)
    {
        if (_currentState != null)
            _currentState.Exit();
        _currentState = StateEnum[desireState];
        _currentState.Enter();
        print($"player in {desireState}state");

    }
    public void TransitionState(PlayerStateType desireState)
    {
        if (_currentState != null)
            _currentState.Exit();
        _currentState = PlayerStateEnum[desireState];
        _currentState.Enter();
        print($"player in {desireState}state");

    }
    protected virtual void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(invincibility)
        {
            invincibilityTimer -= Time.deltaTime;
            if(invincibilityTimer < 0)
            {
                invincibility = false;
            }
        }
        _currentState.StateUpdate();
    }
    private void FixedUpdate()
    {
        _currentState.StateFixedUpdate();
    }

    public void GetHit(int damage, bool ignoreInvincibility, ElementType element , Agent AttackPlayer)
    {
        if (invincibility && !ignoreInvincibility)
        {
            invincibilityTimer = dataCompo.hitInvincibilityTime;
            return;
        }
        int realDamage = ElementDamageUpDown(damage, element, AttackPlayer);
        HealthCompo.Damaged(realDamage);
        invincibility = true;
    }

    public void Healing(int healing)
    {
        HealthCompo.Healing(healing);
    }

    public void HealingPercent(int healing)
    {
        HealthCompo.HealingPercent(healing);
    }

    private int ElementDamageUpDown(int damage, ElementType element , Agent AttackPlayer)
    {
        ElementType myElement = weaponCompo.elementType;
        if(element == ElementType.Special)
        {
            return damage;
        }
        if (element == ElementType.Normal)
        {
            return Mathf.RoundToInt(damage * 0.5f);
        }
        if (myElement == element)
        {
            return Mathf.RoundToInt(damage * 0.75f);
        }
        switch(element)
        {
            case ElementType.Fire:
                if(myElement == ElementType.Water) return 0;
                else if (myElement == ElementType.Wind) return damage;
                else if(myElement == ElementType.Lightning) return Mathf.RoundToInt(damage * 1.5f);
                else return damage;
            case ElementType.Water:
                if (myElement == ElementType.Fire) return Mathf.RoundToInt(damage * 1.5f);
                else if (myElement == ElementType.Wind) return Mathf.RoundToInt(damage * 0.75f);
                else if (myElement == ElementType.Lightning)
                {
                    AttackPlayer.GetHit(Mathf.RoundToInt(damage * 0.25f), true, ElementType.Special, this);
                    return 0;
                }
                else return damage;
            case ElementType.Wind:
                return damage;
            default: return damage;
        }
    }
}
