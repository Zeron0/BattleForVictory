using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactionsPowerView : MonoBehaviour
{
    [SerializeField] private Slider _indicator;
    [SerializeField] private UIComponentsBundle _firstFactionUI;
    [SerializeField] private UIComponentsBundle _secondFactionUI;

    public void Init(Color firstFactionColor, Color secondFactionColor)
    {
        _firstFactionUI.BackgroundOnSlider.color = firstFactionColor;
        _secondFactionUI.BackgroundOnSlider.color = secondFactionColor;
    }

    public void SetIndicatorData(int firstFactionPower, int secondFactionPower)
    {
        _indicator.value = CalculateRatioOfFactionsPower(firstFactionPower, secondFactionPower);
        _firstFactionUI.FactionPowerText.text = firstFactionPower.ToString();
        _secondFactionUI.FactionPowerText.text = secondFactionPower.ToString();
    }

    private float CalculateRatioOfFactionsPower(int firstFactionPower, int secondFactionPower)
    {
        float amount = firstFactionPower + secondFactionPower;
        float ratio = firstFactionPower / amount;

        return ratio;
    }

    [Serializable]
    private class UIComponentsBundle
    {
        [SerializeField] private Text _factionPowerText;
        [SerializeField] private Image _backgroundOnSlider;

        public Text FactionPowerText => _factionPowerText;
        public Image BackgroundOnSlider => _backgroundOnSlider;
    }
}
