using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson1Controller : BaseLessonController
{
    protected override void ExecuteOutput(string s)
    {
        PopupNoticeController.Instance.Notice(s);
        if(s == "Hello World")
        {
            
            Invoke(nameof(EndGame),0.5f);
        }
            
    }
    private void EndGame()
    {
        UIManager.Instance.InitUIEnd();
    }
}
