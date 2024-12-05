using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Treasure : MonoBehaviour
{
    private Animator animator;
    private bool isOpen = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.GetComponent<Player>() && !isOpen)
        {
            isOpen = true;
            collision.GetComponent<Player>().SetCanMove(false);
            animator.SetTrigger("open");
            Invoke(nameof(ExcuteEnd),0.5f);
        }
    }
    private void ExcuteEnd()
    {
        UIManager.Instance.InitUIEnd();
    }
}
