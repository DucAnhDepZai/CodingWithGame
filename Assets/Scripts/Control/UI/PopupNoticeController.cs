using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupNoticeController : MonoBehaviour
{
    public static PopupNoticeController Instance;
    private Animator animator;
    [SerializeField] private Text text;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        animator = GetComponent<Animator>();
    }

    public void Notice(string s)
    {
        text.text = s;
        animator.SetTrigger("notice");
    }
}
