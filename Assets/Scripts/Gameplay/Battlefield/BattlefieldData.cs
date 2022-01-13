using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattlefieldData", menuName = "ScriptableObjects/BattlefieldData", order = 3)]
public class BattlefieldData : ScriptableObject
{
    [Range(10, 500)][SerializeField] private int _maxNumberOfUnits = 10;

    public int MaxNumberOfUnits => _maxNumberOfUnits;
}
