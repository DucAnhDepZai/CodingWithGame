using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lesson2Controller : BaseLessonController
{
    [SerializeField] private GameObject fence;
    [SerializeField] private string triggerOutput;
    protected override void ExecuteOutput(string s)
    {
        PopupNoticeController.Instance.Notice(s);
        if (s == triggerOutput)
        {
            fence.transform.DOMoveY(9, 2).SetEase(Ease.OutQuad);
        }
    }
}
