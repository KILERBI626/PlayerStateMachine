using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State _currentState;

    // "���������" ��� �������������� � ���������� ����� ������ � ������ ������� ( ��������� ������������ ) ((����� �����))
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
        State newState = _currentState.CheckSwitchState();
        if (newState != _currentState) 
        {
            ChangeState(newState);
        }
        _currentState.Update();
    }
}
