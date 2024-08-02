using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR;

public class IdleState : State
{
    PlayerController _player;

    public IdleState(PlayerController context)
    {
        _player = context;
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
    }

    public override State CheckSwitchState()
    {
        Update();
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            return new WalkState(_player);
        }
        return this;
    }
}
