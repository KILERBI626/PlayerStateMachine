using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    public IdleState(PlayerController context)
        : base(context)
    {

    }

    public override void Enter()
    {
        Debug.Log("����� � ���������� �������");
    }

    public override void Exit()
    {
        Debug.Log("����� �� ��������� �������");
    }

    public override void Update()
    {
        Debug.Log("����");
        CheckSwitchState();
    }

    public override State CheckSwitchState()
    {
        if (_player.MovementDirection != Vector3.zero)
        {
            return new WalkState(_player);
        }
        else return this;
    }
}
