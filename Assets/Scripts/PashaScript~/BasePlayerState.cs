using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayerState
{   
    private bool _isJumping = false;
    private MonoBehaviour _player;
    Collider playerCollider;
    Rigidbody playerRb;
    public BasePlayerState(MonoBehaviour player_machine)
    {
        playerRb = player_machine.GetComponent<Rigidbody>();
        playerCollider = player_machine.GetComponent<Collider>();
        _player = player_machine;
    }

    public BasePlayerState(BasePlayerState prev_state)
    {
        _isJumping = prev_state.isJumping();
        playerRb = prev_state.getRigidBody();
        playerCollider = prev_state.getCollider();
        _player = prev_state.getPlayer();
    }

    abstract public void EnterState();


    abstract public BasePlayerState ExitState();
    

    protected Rigidbody getRigidBody()
    {
        return playerRb; 
    }

    protected MonoBehaviour getPlayer()
    {
        return _player;
    }

    protected Collider getCollider() 
    {
        return playerCollider; 
    }

    protected bool isJumping()
    {
        return _isJumping;
    }

    public void setJumping(bool value)
    {
        _isJumping = value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") == true)
        {
            _isJumping = false;
        }
    }
}
