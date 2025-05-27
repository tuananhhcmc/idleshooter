using System;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 36f;
    [SerializeField] private float timeDestroy = 0.36f;
    [SerializeField] private float damage = 10f;
    [SerializeField] GameObject bloodPrefabs;
    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }
    void Update()
    {
        MoveBullet();
    }
    

    void MoveBullet()   
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                GameObject blood = Instantiate(bloodPrefabs, collision.transform.position, Quaternion.identity);
                Destroy(blood , 0.5f);
            }
            Destroy(gameObject);
        }
    }
}
