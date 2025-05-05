using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISavedNotify : MonoBehaviour
{
    [SerializeField] private float _YPositionUp;
    [SerializeField] private float _YPositionDown;

    private RectTransform _thisRectTransform;
    private float _durationMove = 1f;
    private float _durationBeforeHide = 1f;

    private void Start() => 
        _thisRectTransform = GetComponent<RectTransform>();

    private void OnDisable() => 
        _thisRectTransform.position = new Vector2(_thisRectTransform.position.x, _YPositionUp);

    public void Show()
    {
        StartCoroutine(ShowCoroutine());
    }

    private IEnumerator ShowCoroutine()
    {
        Vector2 startPosition = _thisRectTransform.anchoredPosition;
        Vector2 newPosition = new Vector2(startPosition.x, _YPositionDown);

        float step = 0f;

        while (step < _durationMove)
        {
            step += Time.deltaTime;
            float t = Mathf.Clamp01(step / _durationMove);

            _thisRectTransform.anchoredPosition = Vector2.Lerp(startPosition, newPosition, t);

            yield return null;
        }

        yield return new WaitForSeconds(_durationBeforeHide);

        step = 0f;

        while (step < _durationMove)
        {
            step += Time.deltaTime;
            float t = Mathf.Clamp01(step / _durationMove);

            _thisRectTransform.anchoredPosition = Vector2.Lerp(newPosition, startPosition, t);

            yield return null;
        }
    }
}
