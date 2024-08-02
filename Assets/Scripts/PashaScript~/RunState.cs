using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BasePlayerState
{
    MonoBehaviour _player;
    //public RunState(MonoBehaviour player_machine)
    //    : base(player_machine)
    //{
    //    _player = player_machine;
    //}
    public RunState(BasePlayerState prev_state)
        : base(prev_state)
    {
        _player = getPlayer();
    }
    override public void EnterState()
    {
        Run();
    }
    override public BasePlayerState ExitState()
    {
        if (!(Input.GetKey(KeyCode.LeftShift)))
        {
            return new WalkState(this);
        }
        if (JumpState.ChangeToJump(_player, isJumping()))
        {
            return new JumpState(this); 
        }
        return this;
    }

    void Run()
    {
        Vector3 move_axis = new Vector3(Input.GetAxis("Horizontal"), 0, (Input.GetAxis("Vertical")));
        move_axis.Normalize();
        //Debug.Log(move_axis);
        _player.transform.Translate(move_axis * 20 * Time.deltaTime);
        Debug.Log("Running...");
    }

}
