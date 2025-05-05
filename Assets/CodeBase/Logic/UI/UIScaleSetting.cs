using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScaleSetting : MonoBehaviour
{
    private const float MaxValue = 3f;
    private const float MinValue = 0f;
    private const float MaxValueText = 1f;

    [SerializeField] private Slider _slider;
    [SerializeField] private Text _sliderValueText;

    private RectTransform _targetRectTransform;

    public void Init(RectTransform targetRectTransform)
    {
        _targetRectTransform = targetRectTransform;

        InitSlider();
    }

    private void OnEnable() =>
        _slider.onValueChanged.AddListener(ChangeScaleValue);

    private void OnDisable() =>
        _slider.onValueChanged.RemoveListener(ChangeScaleValue);

    private void InitSlider()
    {
        _slider.maxValue = MaxValue;
        _slider.minValue = MinValue;

        _slider.value = _targetRectTransform.localScale.x;

        SetSliderValueText(_slider.value);
    }

    private void ChangeScaleValue(float value)
    {
        _targetRectTransform.localScale = new Vector3(value, value);

        SetSliderValueText(value);
    }

    private void SetSliderValueText(float value)
    {
        int procent = (int)((value - _slider.minValue) / (MaxValueText - _slider.minValue) * 100);

        _sliderValueText.text = $"{procent}%";
    }
}
