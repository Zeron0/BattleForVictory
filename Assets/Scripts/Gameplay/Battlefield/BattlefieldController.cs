using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlefieldController : MonoBehaviour
{
    [SerializeField] private List<FactionHandler> _factionHandlers;
    [SerializeField] private BattlefieldHandler _battlefieldHandler;
    [SerializeField] private FactionPowerPresenter _factionPowerPresenter;

    private FactionHandler _firstFactionHandler;
    private FactionHandler _secondFactionHandler;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        int firstFactionHandlerIndex = 0, secondFactionHandlerIndex = 0;

        while (firstFactionHandlerIndex == secondFactionHandlerIndex)
        {
            firstFactionHandlerIndex = Random.Range(0, _factionHandlers.Count);
            secondFactionHandlerIndex = Random.Range(0, _factionHandlers.Count);
        }

        _firstFactionHandler = _factionHandlers[firstFactionHandlerIndex];
        _secondFactionHandler = _factionHandlers[secondFactionHandlerIndex];

        _firstFactionHandler.Init();
        _secondFactionHandler.Init();
        _firstFactionHandler.StartCreatingUnits();
        _secondFactionHandler.StartCreatingUnits();

        _factionPowerPresenter.Init(_firstFactionHandler.GetInfo, _secondFactionHandler.GetInfo);
    }
}
