using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Lesson3Controller : BaseLessonController
{
    [SerializeField] private BlockController blockController;
 
    protected override void ExecuteOutput(string s)
    {
        try
        {
            string[] ss = s.Split(";");
            if (ss.Length == 2 && ss[0] == "Data")
            {
                int length = Convert.ToInt32(ss[1]);
                blockController.SetRight(length);
            }
        }
        catch 
        {
            PopupNoticeController.Instance.Notice("Input not valid!");
        }
    }
}
