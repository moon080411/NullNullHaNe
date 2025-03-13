using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationState : PlayerMoveState
{
    public PlayerRotationState(Player agent) : base(agent)
    {
    }
    protected override void EnterState()
    {
        _agent.InputCompo.OnMoveEvent += Move;
        _agent.InputCompo.OnJumpKeyEvent += Jump;
        _agent.InputCompo.OnAttackKeyEvent += Attack;
        _agent.InputCompo.OnDashEvent += Dash;
        _agent.RotationAttackCompo.AttackStart();
    }
    public override void StateUpdate()
    {

    }
    public override void StateFixedUpdate()
    {
        base.StateFixedUpdate();
        if (!_agent.HookCompo.isAttach)
        {
            _agent.RbCompo.velocity = new Vector2(_agent.moveDir.x *0.25f * _agent.speed, _agent.RbCompo.velocity.y);
        }
        else
        {
            _agent.RbCompo.AddForce(new Vector2(_agent.moveDir.x * 0.25f *  _agent.speed, 0));
        }
    }
    protected override void ExitState()
    {
        _agent.InputCompo.OnMoveEvent -= Move;
        _agent.InputCompo.OnJumpKeyEvent -= Jump;
        _agent.InputCompo.OnAttackKeyEvent -= Attack;
        _agent.InputCompo.OnDashEvent -= Dash;
        _agent.RotationAttackCompo.AttackEnd();
    }
}
