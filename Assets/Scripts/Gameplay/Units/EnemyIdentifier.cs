using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class EnemyIdentifier : MonoBehaviour
{
    private IDisposable _disposable;
    private IFactionParticipant _enemy;

    private string _factionName;
    private float _range = 5f;
    private bool _search = true;

    private IFactionParticipant GetEnemy => _enemy;

    private void Init(string factionName, float range)
    {
        _factionName = factionName;
        _range = range;
    }

    private void OnTriggerStay(Collider other)
    {
        if (_search && other.TryGetComponent(out IFactionParticipant factionParticipant))
        {
            if (factionParticipant.GetFactionName != _factionName)
            {
                _search = false;
                _enemy = factionParticipant;

                _disposable = Observable.EveryUpdate()
                    .TakeUntilDestroy(gameObject)
                    .Finally(() =>
                    {
                        _search = true;
                    })
                    .Subscribe(_ =>
                    {
                        if ((transform.position - other.transform.position).sqrMagnitude <= _range * _range 
                        || _enemy == null)
                        {
                            _disposable.Dispose(); 
                        }
                    });
            }
        }
    }
}
