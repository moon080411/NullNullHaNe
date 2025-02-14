using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player agent) : base(agent)
    {
    }

    protected override void EnterState()
    {
        MoveCheck();
        base.EnterState();
    }
    public override void StateUpdate()
    {
        base.StateUpdate();
        MoveCheck();
    }
    protected override void ExitState()
    {
        base.ExitState();
    }
}
