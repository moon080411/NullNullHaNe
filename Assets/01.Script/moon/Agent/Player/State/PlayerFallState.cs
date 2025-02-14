using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerMoveState
{
    public PlayerFallState(Player agent) : base(agent)
    {
    }
    protected override void EnterState()
    {
        base.EnterState();
    }
    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
        if (!_agent.HookCompo.isAttach)
        {
            _agent.RbCompo.velocity = new Vector2(_agent.moveDir.x * 0.5f * _agent.speed, _agent.RbCompo.velocity.y);
        }
        else
        {
            _agent.RbCompo.AddForce(new Vector2(_agent.moveDir.x * _agent.speed, 0));
        }
    }
    public override void StateUpdate()
    {
        if(_agent.GroundCheckCompo.isGround)
        {
            _agent.TransitionState(StateType.Idle);
        }
    }
    protected override void ExitState()
    {
        base.ExitState();
    }
}
