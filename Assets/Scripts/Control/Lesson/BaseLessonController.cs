using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLessonController : MonoBehaviour
{
    public Lesson lesson;
    protected abstract void ExecuteOutput(string s);    
    protected void Start()
    {
        GameManager.Instance.execute += ExecuteOutput;

    }
    protected void OnDestroy()
    {
        GameManager.Instance.execute -= ExecuteOutput;
    }
}
