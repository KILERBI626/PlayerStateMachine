using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BasePlayerState
{
    MonoBehaviour _player;
    //public JumpState(MonoBehaviour player_machine)
    //    : base(player_machine)
    //{
    //    _player = player_machine;
    //    setGrounded(false);
    //    setJumping(true);
    //}

    public JumpState(BasePlayerState prev_state)
        : base(prev_state)
    {
        _player = getPlayer();
        setJumping(true);
        Debug.Log("JUMP");
    }

    override public void EnterState()
    {
        Jump();
    }
    override public BasePlayerState ExitState()
    {
            return new IdleState(this);
    }

    static public bool ChangeToJump(MonoBehaviour player_machine, bool isJumping)
        {
        if ((Input.GetKeyDown(KeyCode.Space)) &  !isJumping)
        {
            Debug.Log("isJumping");
            Debug.Log(isJumping);
            return true;
        }
            return false;
        }
    void Jump()
    {
        // через компонент ригидбади добавляем вертикальную скорость объекту
        getRigidBody().velocity = Vector3.up * 10;

        //setJumping(true);

        Debug.Log("Running...");
    }
}
