using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuildPopup : BasePopup
{
    [SerializeField] private Button pre, next, close;
    [SerializeField] private Text text;
    private int curPage;
    private int totalPage;
    private string[] guilds;
    private PopupManager popupManager;
    
    public void Init(PopupManager popupManager ,string list)
    {        
        this.popupManager = popupManager;
        guilds = list.Split(";;");
        curPage = 0;
        totalPage = guilds.Length;
        pre.onClick.RemoveAllListeners();
        pre.onClick.AddListener(OnPreClick);
        next.onClick.RemoveAllListeners();
        next.onClick.AddListener(OnNextClick);
        close.onClick.RemoveAllListeners();
        close.onClick.AddListener(OnCloseClick);
        UpdateUI();
        gameObject.SetActive(true);
        Show();
    }
    private void UpdateUI()
    {
        text.text = guilds[curPage].Trim();
        if (totalPage > 1)
        {
            if (curPage == 0)
            {
                pre.gameObject.SetActive(false);
            }
            else if (curPage == totalPage - 1)
            {
                next.gameObject.SetActive(false);
            }
            else
            {
                pre.gameObject.SetActive(true);
                next.gameObject.SetActive(true);
            }
        }
        else 
        {
            pre.gameObject.SetActive(false);
            next.gameObject.SetActive(false);
        }
    }
    private void OnCloseClick()
    {
        Hide(() =>
        {
            gameObject.SetActive(false);
            popupManager.ClosePopup();
        });
    }
    private void OnPreClick()
    {
        curPage--;
        UpdateUI();
    }
    private void OnNextClick()
    {
        curPage++;
        UpdateUI();
    }
}
