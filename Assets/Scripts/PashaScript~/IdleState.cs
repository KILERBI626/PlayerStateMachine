using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BasePlayerState

{
    MonoBehaviour _player;
    public IdleState(MonoBehaviour player_machine)
        : base(player_machine)
    {
        _player = player_machine;
    }

    public IdleState(BasePlayerState prev_state)
        : base(prev_state)
    {
        _player = getPlayer();
    }
    override public void EnterState()
    {
        Idle();
    }
    override public BasePlayerState ExitState()
    {
        if (( Input.GetAxis("Horizontal") != 0) | (Input.GetAxis("Vertical") != 0))
        {
            return new WalkState(this);
        }
        if (JumpState.ChangeToJump(_player, isJumping()))
        {
            return new JumpState(this);
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
