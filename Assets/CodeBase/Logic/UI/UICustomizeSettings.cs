using UnityEngine;

public class UICustomizeSettings : MonoBehaviour
{
    [SerializeField] private UIScaleSetting _scaleSetting;
    [SerializeField] private UIAlphaSetting _alphaSetting;

    private UICustomizeElement _prevCustomizeElement;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Open(UICustomizeElement prevCustomizeElement, RectTransform targetRectTransform, CanvasGroup targetCanvasGroup)
    {
        _scaleSetting.Init(targetRectTransform);
        _alphaSetting.Init(targetCanvasGroup);

        if (_prevCustomizeElement != null && prevCustomizeElement != _prevCustomizeElement)
            _prevCustomizeElement.Deselect();

        gameObject.SetActive(true);
        _prevCustomizeElement = prevCustomizeElement;
    }

    public void Close()
    {
        if( _prevCustomizeElement != null)
            _prevCustomizeElement.Deselect();
        
        gameObject.SetActive(false);
    }
}
