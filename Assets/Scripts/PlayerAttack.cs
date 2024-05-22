using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform[] shootPoint;
    public GameObject bullet;
    public float bulletSpeed;
    public float bulletKillTime;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var a = Instantiate(bullet, shootPoint[0].position, shootPoint[0].rotation);
            var b = Instantiate(bullet, shootPoint[1].position, shootPoint[1].rotation);
            a.gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed * 10;
            b.gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed * 10;
            EliminateProjectile(a);
            EliminateProjectile(b);
        }
    }
    public void EliminateProjectile(GameObject bullet)
    {
        Destroy(bullet, bulletKillTime);
    }
}
