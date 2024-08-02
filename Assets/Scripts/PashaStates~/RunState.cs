using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IBasePlayerState
{
    MonoBehaviour _player;
    public RunState(MonoBehaviour player_machine)
    {
        _player = player_machine;
    }
    void IBasePlayerState.EnterState()
    {
        Run();
    }
    IBasePlayerState IBasePlayerState.ExitState()
    {
        if (!(Input.GetKey(KeyCode.LeftShift)))
        {
            return new WalkState(_player);
        }
        return this;
    }

    void Run()
    {
        Vector3 move_axis = new Vector3(Input.GetAxis("Horizontal"), 0, (Input.GetAxis("Vertical")));
        move_axis.Normalize();
        Debug.Log(move_axis);
        _player.transform.Translate(move_axis * 20 * Time.deltaTime);
        Debug.Log("Running...");
    }

}
