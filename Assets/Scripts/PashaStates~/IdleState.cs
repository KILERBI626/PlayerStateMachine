using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IBasePlayerState

{
    MonoBehaviour _player;
    public IdleState(MonoBehaviour player_machine)
    {
        _player = player_machine;
    }
    void IBasePlayerState.EnterState()
    {
        Idle();
    }
    IBasePlayerState IBasePlayerState.ExitState()
    {
        if (( Input.GetAxis("Horizontal") != 0) | (Input.GetAxis("Vertical") != 0))
        {
            return new WalkState(_player);
        }
        return this;
    }

    void Idle()
    {
        //Input.GetAxis("Horizontal");
        //_player.transform.Translate(Vector3.forward);
        Debug.Log("Idling...");
    }
}
