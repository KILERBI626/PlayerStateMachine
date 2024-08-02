using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WalkState : IBasePlayerState
{
    MonoBehaviour _player;
    public WalkState(MonoBehaviour player_machine)
    {
        _player = player_machine;
    }
    void IBasePlayerState.EnterState()
    {
        Walk();
    }
    IBasePlayerState IBasePlayerState.ExitState()
    {
        if (!((Input.GetAxis("Horizontal") != 0) | (Input.GetAxis("Vertical") != 0)))
        {
            return new IdleState(_player);
        }

        if(isShiftPressed())
        {
            return new RunState(_player);
        }
        return this;
    }

    void Walk()
    {
        Vector3 move_axis = new Vector3(Input.GetAxis("Horizontal"), 0, (Input.GetAxis("Vertical")));
        move_axis.Normalize();
        Debug.Log(move_axis);
        _player.transform.Translate(move_axis * 10 * Time.deltaTime);
        Debug.Log("Walking...");
    }

    bool isShiftPressed()
    { 
        return Input.GetKey(KeyCode.LeftShift);
    }
}
