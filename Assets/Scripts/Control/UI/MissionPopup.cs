using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionPopup : BasePopup
{
    [SerializeField] private Button close;
    [SerializeField] private Text text;
    private PopupManager popupManager;

    public void Init(PopupManager popupManager, string list)
    {
        this.popupManager = popupManager;
        text.text = list;        
        close.onClick.RemoveAllListeners();
        close.onClick.AddListener(OnCloseClick);
        gameObject.SetActive(true);
        Show();
    }
    private void OnCloseClick()
    {
        Hide(() =>
        {
            gameObject.SetActive(false);
            popupManager.ClosePopup();
        });
        
    }
}
