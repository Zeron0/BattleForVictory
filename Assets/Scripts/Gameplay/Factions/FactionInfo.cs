using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionInfo
{
    public event Action OnInfoChange;

    private int _livingUnits = 0;
    private int _destroyedUnits = 0;

    public int LivingUnits => _livingUnits;
    public int DestroyedUnits => _destroyedUnits;

    public void OnUnitCreate()
    {
        _livingUnits++;

        OnInfoChange?.Invoke();
    }

    public void OnUnitDestroy()
    {
        _livingUnits--;
        _destroyedUnits++;

        OnInfoChange?.Invoke();
    }
}
