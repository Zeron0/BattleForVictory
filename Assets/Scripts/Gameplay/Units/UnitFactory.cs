using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitFactory", menuName = "ScriptableObjects/UnitFactory", order = 1)]
public class UnitFactory : GameObjectFactory
{
    [SerializeField] private UnitConfig _soldier, _tank;

    public BaseUnit Get(UnitType type, FactionData data)
    {
        UnitConfig config = GetConfig(type);
        BaseUnit instance = CreateGameObjectInstance(config.Prefab);

        instance.Init(data, config);

        return instance;
    }

    protected override UnitConfig GetConfig(UnitType type)
    {
        switch (type)
        {
            case UnitType.Soldier:
                return _soldier;

            case UnitType.Tank:
                return _tank;

            default:
                return null;
        }
    }
}
