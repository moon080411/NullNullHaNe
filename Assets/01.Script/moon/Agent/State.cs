using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State
{
    public UnityEvent OnEnter, OnExit;
    public Agent publicAgent;
    public void Enter()
    {
        OnEnter?.Invoke();
        EnterState();
    }
    protected virtual void EnterState()
    {

    }

    public virtual void StateUpdate()
    {
        if (publicAgent.RbCompo.velocity.y < -0.01f)
        {
            publicAgent.TransitionState(StateType.Fall);
        }
    }
    protected virtual void Attack()
    {

    }
    protected virtual void Jump()
    {
        if (publicAgent.GroundCheckCompo.isGround)
        {
            publicAgent.TransitionState(StateType.Jump);
            publicAgent.GroundCheckCompo.isGround = false;
        }
    }
    public virtual void StateFixedUpdate()
    {

    }

    public void Exit()
    {
        OnExit?.Invoke();
        ExitState();
    }

    protected virtual void ExitState()
    {
    }
    protected void print<T>(T msg)
    {
        Debug.Log(msg);
    }
}
