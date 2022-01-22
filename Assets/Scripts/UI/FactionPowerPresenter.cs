using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionPowerPresenter : MonoBehaviour
{
    [SerializeField] private FactionsPowerView _factionsPowerView;

    private FactionInfo _firstFactionInfo;
    private FactionInfo _secondFactionInfo;

    public void Init(FactionInfo firstFactionInfo, FactionInfo secondFactionInfo)
    {
        _firstFactionInfo = firstFactionInfo;
        _secondFactionInfo = secondFactionInfo;

        _firstFactionInfo.OnInfoChange += UpdateData;
        _secondFactionInfo.OnInfoChange += UpdateData;
    }

    private void UpdateData()
    {
        _factionsPowerView.SetIndicatorData(_firstFactionInfo.LivingUnits, _secondFactionInfo.LivingUnits);
    }
}
