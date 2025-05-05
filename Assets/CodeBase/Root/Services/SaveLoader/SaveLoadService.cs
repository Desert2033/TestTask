using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadService : ISaveLoadService
{
    private string _path = Application.persistentDataPath + "/save.json";
    private List<ISavedProgressWriter> _progressWriters = new List<ISavedProgressWriter>();
    private List<ISavedProgressReader> _progressReaders = new List<ISavedProgressReader>();
    private IPersistentProgressService _progressService;
    private IStaticDataService _staticDataService;

    public SaveLoadService(IPersistentProgressService progressService, IStaticDataService staticDataService)
    {
        _progressService = progressService;
        _staticDataService = staticDataService;
    }

    public void RegisterProgressWriter(ISavedProgressWriter writer) => 
        _progressWriters.Add(writer);

    public void RegisterProgressReader(ISavedProgressReader reader) => 
        _progressReaders.Add(reader);

    public PlayerProgress LoadProgress()
    {
        if (File.Exists(_path))
        {
            string json = File.ReadAllText(_path);
            _progressService.Progress = JsonUtility.FromJson<PlayerProgress>(json);

            return _progressService.Progress;
        }
        else 
        {
            _progressService.Progress = new PlayerProgress();
            UIElementData joystickData = new UIElementData(_staticDataService.GetDefaultSettingsById(UIElementId.Joystick));
            UIElementData HealData = new UIElementData(_staticDataService.GetDefaultSettingsById(UIElementId.Heal));
            UIElementData bulletData = new UIElementData(_staticDataService.GetDefaultSettingsById(UIElementId.Bullet));

            _progressService.Progress.JoystickData = joystickData;
            _progressService.Progress.HealData = HealData;
            _progressService.Progress.BulletData = bulletData;
        }

        return null;
    }

    public void NotifyAllReaders()
    {
        foreach (ISavedProgressReader reader in _progressReaders)
        {
            reader.LoadProgess(_progressService.Progress);
        }
    }

    public void SaveProgress()
    {
        foreach (ISavedProgressWriter progressWriter in _progressWriters)
        {
            progressWriter.UpdateProgress(_progressService.Progress);
        }

        string json = JsonUtility.ToJson(_progressService.Progress, true);

        File.WriteAllText(_path, json);

        Debug.Log("Data path: " + _path);
    }

    public void ClearReaders() => 
        _progressReaders.Clear();

    public void ClearWriters() => 
        _progressWriters.Clear();
}
