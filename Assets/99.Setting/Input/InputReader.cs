using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Input;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action OnJumpKeyEvent;
    public event Action OnAttackKeyEvent;
    public event Action<Vector2> OnMoveEvent;
    public event Action OnDashEvent;
    public event Action OnHookEvent;
    private Input _playerInputAction;
    private void OnEnable()
    {
        if (_playerInputAction == null)
        {
            _playerInputAction = new Input();
            _playerInputAction.Player.SetCallbacks(this);
        }
        _playerInputAction.Player.Enable();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnAttackKeyEvent?.Invoke();
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnDashEvent?.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnJumpKeyEvent?.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnHook(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnHookEvent?.Invoke();
        }
    }
}
