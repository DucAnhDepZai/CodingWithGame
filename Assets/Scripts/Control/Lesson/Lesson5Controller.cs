using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson5Controller : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.execute += ExecuteOutput;
    }
    private void ExecuteOutput(string s)
    {
        try
        {
            
        }
        catch
        {
            PopupNoticeController.Instance.Notice("Input not valid!");
        }
    }
}
