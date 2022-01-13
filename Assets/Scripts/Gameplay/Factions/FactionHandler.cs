using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class FactionHandler
{
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private FactionData _factionData;
    [SerializeField] private UnitFactory _unitFactory;

    private IDisposable _disposable;

    private float _creatingInterval = 1f;
    private bool _creationStarted;

    public void StartCreatingUnits()
    {
        if (_creationStarted)
        {
            return;
        }

        _disposable = Observable.Interval(TimeSpan.FromSeconds(_creatingInterval))
            .Subscribe(_ =>
            {
                UnitType type = GetUnitType();
                BaseUnit unit = _unitFactory.Get(type, _factionData);

                SetUnitPosition(unit);
            });
    }

    public void StopCreatingUnits()
    {
        if (!_creationStarted)
        {
            return;
        }

        _disposable.Dispose();
    }

    private Vector3 GetFreeSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].position;
    }

    private UnitType GetUnitType()
    {
        int random = UnityEngine.Random.Range(0, 2);

        return random > 0 ? UnitType.Soldier : UnitType.Tank;
    }

    private void SetUnitPosition(BaseUnit unit)
    {
        unit.transform.position = GetFreeSpawnPoint();
    }
}
