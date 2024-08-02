using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.XR;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WalkState : State
{
    PlayerController _player;

    public WalkState(PlayerController context)
    {
        _player = context;
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

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            _player.transform.Translate(direction * 10 * Time.deltaTime);
        }

    }

    public override State CheckSwitchState()
    {
        Update();
        if (Input.GetAxis("Horizontal") == 0 & Input.GetAxis("Vertical") == 0)
        {
            return new IdleState(_player);
        }
        return this;
    }
}
