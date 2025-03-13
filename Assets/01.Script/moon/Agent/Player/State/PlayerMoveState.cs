using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player agent) : base(agent)
    {

    }

    protected override void EnterState()
    {
        base.EnterState();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        if (Mathf.Abs(_agent.RbCompo.velocity.x) < 0.01f)
        {
            _agent.TransitionState(StateType.Idle);
        }
    }
    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
        if (!_agent.HookCompo.isAttach)
        {
            _agent.RbCompo.velocity = new Vector2(_agent.moveDir.x*_agent.speed, _agent.RbCompo.velocity.y);
        }
        else
        {
            _agent.RbCompo.AddForce(new Vector2(_agent.moveDir.x * _agent.speed, 0));
        }
    }
    protected override void ExitState()
    {
        base.ExitState();
    }
}
