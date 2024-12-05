using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float maxtop;
    [SerializeField]
    private float maxbottom;
    [SerializeField]
    private float maxleft;
    [SerializeField]
    private float maxright;

    private void Awake()
    {
         
    }
    void Start()
    {
       
        
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
    private float Min(float a, float b)
    {
        if (a < b) return a;
        return b;
    }
    private float Max(float a, float b)
    {
        if (a > b) return a;
        return b;
    }
}
