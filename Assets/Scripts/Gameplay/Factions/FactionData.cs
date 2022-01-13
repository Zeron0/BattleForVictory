using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FactionData", menuName = "ScriptableObjects/FactionData", order = 2)]
public class FactionData : ScriptableObject
{
    [SerializeField] private Color _factionColor;

    [SerializeField] private string _factionName;

    public Color FactionColor => _factionColor;

    public string FactionName => _factionName;
}
