using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StationBehaviour : MonoBehaviour, IStateSwitcher
{
    [SerializeField] private BaseUnit _unit;

    private Dictionary<Type, BaseState> _states;

    private BaseState _currentState;

    public void Init()
    {
        _states = new Dictionary<Type, BaseState>();

        _states[typeof(OffensiveState)] = new OffensiveState();
        _states[typeof(DefenceState)] = new DefenceState();
    }

    public void SwitchState<T>(BaseState state) where T : BaseState
    {
        _currentState.Stop();
        _currentState = state;
        _currentState.Start();
    }

    public void SwitchState<T>() where T : BaseState
    {
        throw new NotImplementedException();
    }

    private BaseState GetState<T>() where T : BaseState
    {
        Type type = typeof(T);

        return _states[type];
    }
}
