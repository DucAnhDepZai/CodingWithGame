using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool canMove = true;
    [SerializeField]
    private bool canTalk = true;

    [SerializeField]
    private float moveFocre = 10f;
    [SerializeField]
    private float jumpForce = 12f;
    [SerializeField]
    private float movementX;
    private float movementY;
    private Rigidbody2D myBody;
    private SpriteRenderer myRenderer;
    private Animator playerAnim;
    public GameObject playerText;

    public TextMeshProUGUI pText;
    private Coroutine sayCoroutine;
    private Vector3 spawnPos;   

    private bool onGround = true;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        playerAnim = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();

        
    }
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            PlayerMoveKeyBoard();
            AnimatePlayer();
            PlayerJump();
        }
      
    }
    public void SetOutput(String s)
    {
        pText.text = s;
        GameManager.Instance.consoleOutput = s;
        if (canTalk)
        {
            if (sayCoroutine != null) StopCoroutine(sayCoroutine);
            sayCoroutine = StartCoroutine(Say(s));
        }
        GameManager.Instance.ExecuteHandler();
    }
    public void SetCanMove(bool b)
    {
        canMove = b;
        playerAnim.SetBool("Run", false);
        playerAnim.SetBool("IsJumping", false);
    }
    IEnumerator Say(String s)
    {
        playerText.SetActive(true);
        yield return new WaitForSeconds(4);
        playerText.SetActive(false);

    }
    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxis("Horizontal");
  
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveFocre;
        
        playerText.transform.position = transform.position + new Vector3(7f,0.3f,0f);

    }
    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            playerAnim.SetBool("Run", true);
            myRenderer.flipX = false;
        }
        else if(movementX == 0){
            playerAnim.SetBool("Run", false);
           
        }
        else
        {
            playerAnim.SetBool("Run", true);
            myRenderer.flipX = true;
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && onGround)
        {
            playerAnim.SetBool("IsJumping", true);
            myBody.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            playerAnim.SetBool("IsJumping", false);
        }
        if (collision.gameObject.CompareTag("Death"))
        {
            transform.position = spawnPos;
            GameManager.Instance.deathCount++;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;          
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
