using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : State
{
    
    public FallState(PlayerController context)
        : base(context)
    {

    }

    public override void Enter()
    {
        Debug.Log("Начинаю падать");
    }

    public override void Exit()
    {
        Debug.Log("Упал");
    }

    public override void Update()
    {
        Debug.Log("Падаю");
    }
    public override State CheckSwitchState()
    {
        return new FallState(_player);
    }
}
