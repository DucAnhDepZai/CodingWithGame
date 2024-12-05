using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private InputField inputField;
    [SerializeField] private Button guildBtn, missionBtn;
    [SerializeField] private Button button;
    [SerializeField] private UIEnd uiEnd;
    public Camera cameraUI;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnBtnClick);

        guildBtn.onClick.RemoveAllListeners();
        guildBtn.onClick.AddListener(OnClickGuild);
        missionBtn.onClick.RemoveAllListeners();
        missionBtn.onClick.AddListener(OnClickMission);
    }
    public void InitUIEnd()
    {
        uiEnd.Init(this);
    }

    private void OnBtnClick()
    {
        GameManager.Instance.consoleOutput = inputField.text;      
        GameManager.Instance.ExecuteHandler();
    }

    private void OnClickGuild()
    {
        PopupManager.Instance.InitGuildPopup();
    }
    private void OnClickMission()
    {
        PopupManager.Instance.InitMissionPopup();
    }

}
