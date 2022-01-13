using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitConfig
{
    public BaseUnit Prefab;

    [Range(10, 1000)] [SerializeField] private int _healthPoints = 10;

    [Range(10, 100)] [SerializeField] private float _moveSpeed = 10f;

    public int HealthPoiints => _healthPoints;
    public float MoveSpeed => _moveSpeed;
}
