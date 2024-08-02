using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WalkState : State
{

    public WalkState(PlayerController context)
        : base(context)
    {

    }

    public override void Enter()
    {
        Debug.Log("Вошел в состояние ходьбы");
    }

    public override void Exit()
    {
        Debug.Log("Вышел из состояния ходьбы");
    }

    public override void Update()
    {
        Debug.Log("Иду");

        CheckSwitchState();

        _player.transform.Translate(_player.MovementDirection * _player.WalkSpeed * Time.deltaTime);

    }

    public override State CheckSwitchState()
    {
        if (_player.MovementDirection == Vector3.zero)
        {
            return new IdleState(_player);
        }
        if (_player.IsRunPressed)
        {
            return new RunState(_player);
        }
        if (_player.IsCrouchPressed)
        {
            return new CrouchState(_player);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            return new JumpState(_player);
        }
        else return this;
    }
}
