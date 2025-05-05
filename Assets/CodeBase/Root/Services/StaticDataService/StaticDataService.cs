using UnityEngine;

public class StaticDataService : IStaticDataService
{
    private static DefaultSettingsStaticData _defaultSettings;

    public void LoadDefaultSettings(DefaultSettingsStaticData defaultSettings) =>
        _defaultSettings = defaultSettings;

    public UIElementData GetDefaultSettingsById(UIElementId id)
    {
        switch (id)
        {
            case UIElementId.Joystick:
                return _defaultSettings.JoystickStaticData;
                break;
            case UIElementId.Heal:
                return _defaultSettings.HealStaticData;
                break;
            case UIElementId.Bullet:
                return _defaultSettings.BulletStaticData;
                break;
        }

        return null;
    }
}
