public interface IStaticDataService : IService
{
    UIElementData GetDefaultSettingsById(UIElementId id);
    void LoadDefaultSettings(DefaultSettingsStaticData defaultSettings);
}