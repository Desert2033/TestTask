using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class UIDefaultButton : MonoBehaviour
{
    [SerializeField] private UICustomizeElement[] _customizeElements;
    [SerializeField] private UICustomizeSettings _UICustomizeSettings;

    private Button _thisButton;
    private IStaticDataService _staticDataService;

    [Inject]
    public void Construct(IStaticDataService staticDataService) => 
        _staticDataService = staticDataService;

    private void OnEnable()
    {
        _thisButton = GetComponent<Button>();

        _thisButton.onClick.AddListener(SetDefaultSettings);
    }

    private void OnDisable() =>
        _thisButton.onClick.RemoveListener(SetDefaultSettings);

    private void SetDefaultSettings()
    {
        _UICustomizeSettings.Close();

        foreach (UICustomizeElement item in _customizeElements)
        {
            UIElementData data = _staticDataService.GetDefaultSettingsById(item.Id);

            item.SetData(data.Position, data.Scale, data.Alpha);
        }
    }
}
