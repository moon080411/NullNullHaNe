using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerMoveState
{
    public PlayerJumpState(Player agent) : base(agent)
    {
    }
    protected override void EnterState()
    {
        base.EnterState();
        _agent.RbCompo.AddForce(Vector3.up * _agent.DataCompo.jumpPower, ForceMode2D.Impulse);
    }
    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
        if (!_agent.HookCompo.isAttach)
        {
            _agent.RbCompo.velocity = new Vector2(_agent.moveDir.x*0.5f*_agent.speed, _agent.RbCompo.velocity.y);
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
