using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : State
{

    public GroundedState(PlayerController context)
        : base(context)
    {

    }

    public override void Enter()
    {
        Debug.Log("Вошел в контакт с землей");
    }

    public override void Exit()
    {
        Debug.Log("Потерял контакт с землей");
    }

    public override void Update()
    {
        Debug.Log("На земле");
        CheckSwitchState();
    }

    public override State CheckSwitchState()
    {
        if (_player.IsJumpPressed)
        {
            return new JumpState(_player);
        }
        else return this;
    }
}
