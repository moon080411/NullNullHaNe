using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    #region component region
    [field: SerializeField] public InputReader InputCompo { get; private set; }
    public PlayerData DataCompo => (PlayerData)dataCompo;
    public GrapplingHook HookCompo;
    #endregion
    public Vector2 moveDir;
    public float DashTime { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        HookCompo = GetComponent<GrapplingHook>();
        DashTime = 0;
        InputCompo.OnAttackKeyEvent += SwitchAttack;
        InputCompo.OnHookEvent += HookCompo.Hook;
    }
    protected override void Update()
    {
        base.Update();
        if(DashTime > 0)
        {
            DashTime -= Time.deltaTime;
        }
    }
    public void SetDashTime()
    {
        DashTime = DataCompo.dashCoolTime;
    }
    public override void InitializeState()
    {
        foreach (StateType stateType in Enum.GetValues(typeof(StateType)))
        {
            string enumName = stateType.ToString();
            Type t = Type.GetType($"Player{enumName}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            StateEnum.Add(stateType, state);
        }
    }
}
