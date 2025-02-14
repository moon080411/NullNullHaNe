using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class PlayerState : State
{
    protected Player _agent;
    public PlayerState(Player agent)
    {
        _agent = agent;
        publicAgent = agent;
    }
    protected override void EnterState()
    {
        _agent.InputCompo.OnMoveEvent += Move;
        _agent.InputCompo.OnJumpKeyEvent += Jump;
        _agent.InputCompo.OnAttackKeyEvent += Attack;
        _agent.InputCompo.OnDashEvent += Dash;
    }
    protected override void ExitState()
    {
        _agent.InputCompo.OnMoveEvent -= Move;
        _agent.InputCompo.OnJumpKeyEvent -= Jump;
        _agent.InputCompo.OnAttackKeyEvent -= Attack;
        _agent.InputCompo.OnDashEvent -= Dash;
    }
    protected virtual void MoveCheck()
    {
        if (Mathf.Abs(_agent.moveDir.x) > 0.01f)
        {
            _agent.TransitionState(StateType.Move);
        }
    }
    protected virtual void Dash()
    {
        if(_agent.DashTime <= 0)
        {
            _agent.TransitionState(StateType.Dash);
        }
    }
    protected virtual void Move(Vector2 dir)
    {
        _agent.moveDir = dir;
        _agent.FilpCompo.Filp(dir.x);
    }
}
