using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    private float timer;
    private float gravity;
    public PlayerDashState(Player agent) : base(agent)
    {
    }
    protected override void EnterState()
    {
        base.EnterState();
        _agent.SetDashTime();
        gravity = _agent.RbCompo.gravityScale;
        _agent.RbCompo.gravityScale = 0;
        _agent.RbCompo.velocity = Vector2.zero;
        timer = _agent.DataCompo.dashTime;
        _agent.RbCompo.AddForce(Vector2.right * _agent.FilpCompo.FilpWay * _agent.DataCompo.dashSpeed, ForceMode2D.Impulse);
    }
    public override void StateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            _agent.TransitionState(StateType.Idle);
        }
    }
    protected override void ExitState()
    {
        _agent.RbCompo.gravityScale = gravity;
        _agent.RbCompo.velocity = new Vector2(0, _agent.RbCompo.velocity.y);
        base.ExitState();
    }
}
