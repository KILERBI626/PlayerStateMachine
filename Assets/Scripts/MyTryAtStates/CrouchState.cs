using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : State
{
    State _previousState;

    public CrouchState(PlayerController context)
        : base(context)
    {

    }

    public override void Enter()
    {
        Debug.Log("Вошел в стостояние приседа");
    }

    public override void Exit()
    {
        Debug.Log("Вышел из стостояния приседа");
    }

    public override void Update()
    {
        Debug.Log("Крадусь");
        _player.transform.Translate(_player.MovementDirection * _player.CrouchSpeed * Time.deltaTime);
    }

    public override State CheckSwitchState()
    {
        if (!_player.IsCrouchPressed)
        {
            return _previousState;
        }
        return this;
    }
}
