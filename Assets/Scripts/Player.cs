using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed =5f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.linearVelocity=playerInput.normalized*moveSpeed;
        if (playerInput.x < 0)
        {
            sr.flipX = true;
        }else if (playerInput.x > 0)
        {
            sr.flipX = false;
        }
        if (playerInput != Vector2.zero)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    public void TakeDamage()
    {
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
