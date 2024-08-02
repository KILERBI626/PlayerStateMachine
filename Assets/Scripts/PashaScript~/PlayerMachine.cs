using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMachine : MonoBehaviour
{

    BasePlayerState _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = new IdleState(this);
    }

    // Update is called once per frame
    void Update()
    {
        _player.EnterState();
        _player = _player.ExitState();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") == true)
        {
            _player.setJumping(false); 
        }
    }
}
