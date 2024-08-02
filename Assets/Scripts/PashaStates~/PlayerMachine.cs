using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMachine : MonoBehaviour
{
    IBasePlayerState _player;
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
}
