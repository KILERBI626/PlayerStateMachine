using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public StateMachine _machine;

    private void Awake()
    {
        _machine = new StateMachine();
        _machine.Initialize(new IdleState(this));
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _machine.UpdateState();
    }
}