using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance; 
    [SerializeField] private GameObject background;
    [SerializeField] private GuildPopup guildPopup;
   
    [SerializeField] private MissionPopup missionPopup;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void InitGuildPopup()
    {
        background.SetActive(true);
        string s = FindAnyObjectByType<BaseLessonController>().GetComponent<BaseLessonController>().lesson.guild;
        guildPopup.Init(this, s);
    }

    public void InitMissionPopup()
    {
        background.SetActive(true);
        string s = FindAnyObjectByType<BaseLessonController>().GetComponent<BaseLessonController>().lesson.mission;
        missionPopup.Init(this, s);
    }
    public void ClosePopup()
    {
        background.SetActive(false);
    }
}
