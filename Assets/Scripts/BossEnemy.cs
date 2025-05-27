using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedDanThuong = 20f;

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BanDanThuong();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                player.TakeDamage(enterDamage);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                player.TakeDamage(stayDamage);
        }
    }

    private void BanDanThuong()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - transform.position;
            directionToPlayer.Normalize();
            GameObject bullet =Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(directionToPlayer * speedDanThuong);
        }
    }

    private void BanDanVongTron()
    {
        const int bulletCount = 12;
        float angleStep = 360f / bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = angleStep * i;    
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));
        }
    }

    private void HoiMau()
    {
        
    }

    private void SinhMiniEnemy()
    {
        
    }

    private void DichChuyen()
    {
        
    }
}
