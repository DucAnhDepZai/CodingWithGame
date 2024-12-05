using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string consoleOutput;
    public int deathCount = 0;
    public int timeFinish = 0;
    public Action<String> execute; 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void ExecuteHandler()
    {
        execute?.Invoke(consoleOutput);
    }
    private void Update()
    {
        timeFinish++;
    }
    public void SetOutput(string s)
    {
        consoleOutput = s;
        ExecuteHandler();
    }

    public void SetError(string s)
    {
        PopupNoticeController.Instance.Notice(s);
    }


}
