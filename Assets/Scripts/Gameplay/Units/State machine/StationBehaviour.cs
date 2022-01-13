using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StationBehaviour : MonoBehaviour, IStateSwitcher
{
    [SerializeField] private BaseUnit _unit;

    private List<BaseState> _states;

    private BaseState _currentState;

    public void SwitchState<T>() where T : BaseState
    {
        _currentState.Stop();
        _currentState = _states.FirstOrDefault(s => s is T);
        _currentState.Start();
    }
}
