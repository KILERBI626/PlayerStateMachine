using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class JumpState : State
{
    State _previousState;

    public JumpState(PlayerController context)
        : base(context)
    {

    }

    public override void Enter()
    {
        Debug.Log("Вошел в стостояние прыжка");
    }

    public override void Exit()
    {
        Debug.Log("Вышел из стостояния прыжка");
    }

    public override void Update()
    {

    }

    public override State CheckSwitchState()
    {
        if(!Input.GetKey(KeyCode.Space))
        {
            return _previousState;
        }
        return this;
    }
}
