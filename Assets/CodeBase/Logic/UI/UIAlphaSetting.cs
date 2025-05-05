using System;
using UnityEngine;
using UnityEngine.UI;

public class UIAlphaSetting : MonoBehaviour
{
    private const float MaxValue = 1f;
    private const float MinValue = 0f;

    [SerializeField] private Slider _slider;
    [SerializeField] private Text _sliderValueText;

    private CanvasGroup _targetCanvasGroup;

    public void Init(CanvasGroup targetCanvasGroup)
    {
        _targetCanvasGroup = targetCanvasGroup;

        InitSlider();
    }

    private void OnEnable() => 
        _slider.onValueChanged.AddListener(ChangeAlphaValue);

    private void OnDisable() => 
        _slider.onValueChanged.RemoveListener(ChangeAlphaValue);

    private void InitSlider()
    {
        _slider.maxValue = MaxValue;
        _slider.minValue = MinValue;

        _slider.value = _targetCanvasGroup.alpha;
        SetSliderValueText(_slider.value);
    }

    private void ChangeAlphaValue(float value)
    {
        _targetCanvasGroup.alpha = value;

        SetSliderValueText(value);
    }

    private void SetSliderValueText(float value)
    {
        int procent = (int)((value - _slider.minValue) / (_slider.maxValue - _slider.minValue) * 100);

        _sliderValueText.text = $"{procent}%";
    }
}
