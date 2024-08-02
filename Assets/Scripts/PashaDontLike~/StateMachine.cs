using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State _currentState;

    // "интерфейс" дл€ взаимодействи€ с переменной этого класса в других классах ( созран€ем инкапсул€цию ) ((хуйн€ кароч))
    public State CurrentState { get { return _currentState; } set { _currentState = value; } }

    public void Initialize(State startState)
    {
        _currentState = startState;
        _currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void UpdateState()
    {

        State new_state = _currentState.CheckSwitchState();
        if (new_state != _currentState)
        {
            ChangeState(new_state);
        }
    }
}
