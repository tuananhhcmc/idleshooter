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
        Destroy(gameObject);
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
