using UnityEngine;
using DG.Tweening;
using System;

public class BasePopup : MonoBehaviour
{
    private RectTransform notificationPanel; 
    private float animationDuration = 0.5f;
    private Vector3 hiddenScale = Vector3.zero;
    private Vector3 shownScale = Vector3.one;   

    protected void Show()
    {       
        notificationPanel = GetComponent<RectTransform>();
        notificationPanel.localScale = hiddenScale;
        notificationPanel.gameObject.SetActive(true);
        notificationPanel.DOScale(shownScale, animationDuration).SetEase(Ease.OutBack);
    }

    protected void Hide(Action callback)
    {       
        notificationPanel.DOScale(hiddenScale, animationDuration)
            .SetEase(Ease.InBack)
            .OnComplete(() => callback.Invoke());
    }
}
