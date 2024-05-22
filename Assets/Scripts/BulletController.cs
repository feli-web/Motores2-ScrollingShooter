using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public float fireRate = 0.1f;

    private float nextFire = 0f;

    private void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            SpawnPattern();
            //SpawnSpiralPattern();
        }
    }

    void SpawnPattern()
    {
        // Example pattern: Circular Pattern
        int bulletCount = 10;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * Mathf.PI * 2f / bulletCount;
            Vector3 bulletDir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            SpawnBullet(bulletDir);
        }
    }

    void SpawnBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }

    void SpawnSpiralPattern()
    {
        float angleStep = 10f;
        float angle = 0f;

        for (int i = 0; i < 36; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector3 bulletMoveDirection = (bulletVector - transform.position).normalized * bulletSpeed;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDirection.x, bulletMoveDirection.y);

            angle += angleStep;
        }
    }

    void SpawnWavePattern()
    {
        float startAngle = -45f;
        float endAngle = 45f;
        int bulletCount = 10;

        float angleStep = (endAngle - startAngle) / bulletCount;
        float angle = startAngle;

        for (int i = 0; i < bulletCount + 1; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector3 bulletMoveDirection = (bulletVector - transform.position).normalized * bulletSpeed;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletMoveDirection.x, bulletMoveDirection.y);

            angle += angleStep;
        }
    }
}
