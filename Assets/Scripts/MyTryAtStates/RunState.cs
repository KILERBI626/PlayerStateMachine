using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{

    public RunState(PlayerController context)
        : base(context)
    {

    }

    public override void Enter()
    {
        Debug.Log("����� � ��������� ����");
    }

    public override void Exit()
    {
        Debug.Log("����� �� ��������� ����");
    }

    public override void Update()
    {
        Debug.Log("����");

        CheckSwitchState();

        _player.transform.Translate(_player.MovementDirection * _player.RunSpeed * Time.deltaTime);
    }

    public override State CheckSwitchState()
    {
        if (!_player.IsRunPressed)
        {
            return new WalkState(_player);
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
