using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class UICustomizeElement : MonoBehaviour, IDragHandler, IPointerDownHandler, ISavedProgressReader, ISavedProgressWriter
{
    [SerializeField] private UIElementId _id;
    [SerializeField] private GameObject _selectImage;
    [SerializeField] private Canvas _rootCanvas;
    [SerializeField] private UICustomizeSettings _customizeSettings;
    
    private RectTransform _thisRectTransform;
    private CanvasGroup _thisCanvasGroup;
    private ISaveLoadService _saveLoadService;

    public UIElementId Id => _id;

    [Inject]
    public void Construct(ISaveLoadService saveLoadService)
    {
        _saveLoadService = saveLoadService;
    }

    private void OnEnable()
    {
        _thisRectTransform = GetComponent<RectTransform>();
        _thisCanvasGroup = GetComponent<CanvasGroup>();

        _saveLoadService.RegisterProgressWriter(this);
        _saveLoadService.RegisterProgressReader(this);

        Deselect();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _thisRectTransform.anchoredPosition += eventData.delta / _rootCanvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Select();

        _customizeSettings.Open(this, _thisRectTransform, _thisCanvasGroup);
    }

    public void LoadProgess(PlayerProgress progress)
    {
        UIElementData elementData = null;

        switch (_id)
        {
            case UIElementId.Joystick:
                elementData = progress.JoystickData;
                break;
            case UIElementId.Heal:
                elementData = progress.HealData;
                break;
            case UIElementId.Bullet:
                elementData = progress.BulletData;
                break;
        }

        SetData(elementData.Position, elementData.Scale, elementData.Alpha);
    }

    public void UpdateProgress(PlayerProgress progress)
    {
        UIElementData elementData = null;

        switch (_id)
        {
            case UIElementId.Joystick:
                elementData = progress.JoystickData;
                break;
            case UIElementId.Heal:
                elementData = progress.HealData;
                break;
            case UIElementId.Bullet:
                elementData = progress.BulletData;
                break;
        }

        elementData.SetData(_thisRectTransform.anchoredPosition, _thisRectTransform.localScale, _thisCanvasGroup.alpha);
    }

    public void SetData(Vector2 position, Vector2 scale, float alpha)
    {
        _thisRectTransform.anchoredPosition = position;
        _thisRectTransform.localScale = scale;
        _thisCanvasGroup.alpha = alpha;
    }

    public void Select() =>
        _selectImage.SetActive(true);

    public void Deselect() =>
        _selectImage.SetActive(false);
}
