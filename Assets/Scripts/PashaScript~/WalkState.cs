using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WalkState : BasePlayerState
{
    MonoBehaviour _player;
    /*
    public WalkState(MonoBehaviour player_machine)
        : base(player_machine)
    {
        _player = player_machine;
    }
    */

    public WalkState(BasePlayerState prev_state)
        : base(prev_state)
    {
        _player = getPlayer();
    }
    override public void EnterState()
    {
        Walk();
    }
    override public BasePlayerState ExitState()
    {
        if (!((Input.GetAxis("Horizontal") != 0) | (Input.GetAxis("Vertical") != 0)))
        {
            return new IdleState(this);
            
        }

        if(isShiftPressed())
        {
            return new RunState(this);
        }
        if (JumpState.ChangeToJump(_player, isJumping()))
        {
            return new JumpState(this);
        }
        return this;
    }

    void Walk()
    {
        Vector3 move_axis = new Vector3(Input.GetAxis("Horizontal"), 0, (Input.GetAxis("Vertical")));
        move_axis.Normalize();
        //Debug.Log(move_axis);
        _player.transform.Translate(move_axis * 10 * Time.deltaTime);
        Debug.Log("Walking...");
    }

    bool isShiftPressed()
    { 
        return Input.GetKey(KeyCode.LeftShift);
    }
}
