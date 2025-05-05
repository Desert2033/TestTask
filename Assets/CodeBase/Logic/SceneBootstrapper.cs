using UnityEngine;
using Zenject;

public class SceneBootstrapper : MonoBehaviour
{
    [SerializeField] private DefaultSettingsStaticData _defaultSettings;
    
    private IStaticDataService _staticDataService;
    private ISaveLoadService _saveLoadService;

    [Inject]
    public void Construct(IStaticDataService staticDataService, ISaveLoadService saveLoadService)
    {
        _staticDataService = staticDataService;
        _saveLoadService = saveLoadService;
    }

    private void Awake()
    {
        _staticDataService.LoadDefaultSettings(_defaultSettings);
        _saveLoadService.LoadProgress();
    }

    private void Start()
    {
        _saveLoadService.NotifyAllReaders();
    }

    private void OnDisable()
    {
        _saveLoadService.ClearReaders();
        _saveLoadService.ClearWriters();
    }
}
