using System;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed =5f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    [SerializeField] private float maxHp = 100f;
    private float currentHp;
    [SerializeField] private Image hpBar;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        currentHp = maxHp;
        UpdateHpBar();
    }

    private Vector2 _playerInput;
    private void FixedUpdate()
    {
        MovePlayer();

    }

    void Update()
    {
        _playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.PauseGameMenu();
        }
    }

    void MovePlayer()
    {
        rb.linearVelocity=_playerInput.normalized * (moveSpeed * Time.fixedDeltaTime);
        //rb.linearVelocity = _playerInput.normalized * moveSpeed;
        if (_playerInput.x < 0)
        {
            sr.flipX = true;
        }else if (_playerInput.x > 0)
        {
            sr.flipX = false;
        }
        if (_playerInput != Vector2.zero)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    public void TakeDamage(float damage)
    {   
        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameManager.GameOverMenu();
    }

    private void UpdateHpBar()
    {
        if(hpBar != null) 
        {
            hpBar.fillAmount = currentHp / maxHp;
        }
    }

    public void Heal(float healValue)
    {
        if (currentHp < maxHp)
        {
            currentHp += healValue;
            currentHp = Mathf.Min(currentHp, maxHp);
            UpdateHpBar();
        }
    }
}
