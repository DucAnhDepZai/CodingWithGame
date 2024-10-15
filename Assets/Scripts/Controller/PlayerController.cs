using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool start;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {        
        rb.AddForce(Vector2.right * 5 * Time.deltaTime,ForceMode2D.Impulse);
        
    }
}
