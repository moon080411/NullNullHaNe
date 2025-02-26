using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle,
    Move,
    Attack,
    Jump,
    Dash,
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

    public Transform myTra;

    private float timer;

    private float invincibilityTimer;

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
    protected virtual void Start()
    {
        TransitionState(StateType.Idle);
    }

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
    protected virtual void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        _currentState.StateUpdate();
    }
    private void FixedUpdate()
    {
        _currentState.StateFixedUpdate();
    }

    public void GetHit(int damage)
    {
        HealthCompo.Damaged(damage);
    }
}
