using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson4Controller : BaseLessonController
{
    [SerializeField] private BlockController blockController,blockController2;

    protected override void ExecuteOutput(string s)
    {
        try
        {
            string[] ss = s.Split(";");
            if (ss.Length == 3 && ss[0] == "Data")
            {
                int length = Convert.ToInt32(ss[1]);
                blockController.SetLeft(length);
                int length2 = Convert.ToInt32(ss[2]);
                blockController2.SetRight(length2);
            }
        }
        catch
        {
            PopupNoticeController.Instance.Notice("Input not valid!");
        }
    }
}
