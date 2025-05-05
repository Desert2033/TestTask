public class PlayerProgress
{
    public UIElementData JoystickData;
    public UIElementData HealData;
    public UIElementData BulletData;

    public PlayerProgress()
    {
        JoystickData = new UIElementData(UIElementId.Joystick);
        HealData = new UIElementData(UIElementId.Heal);
        BulletData = new UIElementData(UIElementId.Bullet);
    }
}