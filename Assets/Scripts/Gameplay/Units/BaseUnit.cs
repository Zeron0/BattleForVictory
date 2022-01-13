using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour, IDamageable, IFactionParticipant
{
    [SerializeField] protected List<MeshRenderer> _meshRenderers;

    protected FactionData _factionData;

    protected int _healthPoints;
    protected float _moveSpeed;

    private const string NAME_OF_MATERIAL_FOR_COLOR_FACTION = "MaterialForColorFaction (Instance)";
    private const float DELAY_BEFORE_DESTRUCTION = 1.5f;

    private bool _isDestroyed;

    public string GetFactionName => _factionData.FactionName;

    public virtual void Init(FactionData factionData, UnitConfig unitConfig)
    {
        _healthPoints = unitConfig.HealthPoiints;
        _moveSpeed = unitConfig.MoveSpeed;
        _factionData = factionData;

        SetFactionColor(factionData.FactionColor);
    }

    public void TakeDamage(int damage)
    {
        if (_isDestroyed)
        {
            return;
        }

        _healthPoints -= damage;

        if (_healthPoints <= 0)
        {
            _isDestroyed = true;
            Observable.Timer(TimeSpan.FromSeconds(DELAY_BEFORE_DESTRUCTION))
                .Subscribe(_ =>
                {
                    Destroy(gameObject);
                });
        }
    }

    private void SetFactionColor(Color color)
    {
        foreach (MeshRenderer meshRenderer in _meshRenderers)
        {
            foreach (Material material in meshRenderer.materials)
            {
                if (material.name == NAME_OF_MATERIAL_FOR_COLOR_FACTION)
                {
                    material.color = color;
                }
            }
        }
    }
}

public enum UnitType
{
    Soldier,
    Tank
}
