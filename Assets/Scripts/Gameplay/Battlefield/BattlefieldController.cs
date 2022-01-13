using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldController : MonoBehaviour
{
    [SerializeField] private List<FactionHandler> _factionHandlers;
    [SerializeField] private BattlefieldHandler _battlefieldHandler;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        foreach (FactionHandler factionHandler in _factionHandlers)
        {
            factionHandler.StartCreatingUnits();
        }
    }

}
