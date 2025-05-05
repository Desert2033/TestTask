using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class UISaveButton : MonoBehaviour
{
    [SerializeField] private UICustomizeSettings _customizeSettings;
    [SerializeField] private UISavedNotify _uiSavedNotify;

    private Button _thisButton;
    private ISaveLoadService _saveLoadService;

    [Inject]
    public void Construct(ISaveLoadService saveLoadService)
    {
        _saveLoadService = saveLoadService;
    }

    private void OnEnable()
    {
        _thisButton = GetComponent<Button>();

        _thisButton.onClick.AddListener(Save);
    }

    private void OnDisable()
    {
        _thisButton.onClick.RemoveListener(Save);
    }

    private void Save()
    {
        _customizeSettings.Close();
        _uiSavedNotify.Show();

        _saveLoadService.SaveProgress();
    }
}
