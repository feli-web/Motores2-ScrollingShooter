using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Boss : MonoBehaviour
{
    [Header("Life")]
    public int maxLife;
    int life;
    public Slider lifeSlider;
    public MovingBackground mb;
    SpriteRenderer sr;

    [Header("Movement")]
    public float speed;
    public Transform[] target;
    int designatedTarget;

    [Header("Attack")]
    public BulletSpawner[] bs;

    void Start()
    {
        life = maxLife;
        lifeSlider.minValue = 0; lifeSlider.maxValue = maxLife;
        sr = GetComponent<SpriteRenderer>();
        designatedTarget = 0;
    }

    void FixedUpdate()
    {
        if (life > (maxLife * 0.5f))
        {
            Movement1();
        }
        else
        {
            Invoke("Movement2", 0.5f);
        }
    }
    
        public void Movement1()
    {
        if (target == null || target.Length == 0 || designatedTarget >= target.Length)
            return;

        Vector3 direction = (target[designatedTarget].position - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * speed * Time.fixedDeltaTime;
        transform.position = newPosition;
        float distanceToTarget = Vector3.Distance(transform.position, target[designatedTarget].position);

        if (distanceToTarget < 0.1f)
        {
            designatedTarget++;
        }

        if (designatedTarget >= target.Length)
        {
            designatedTarget = 0;
        }
    }

    public void Movement2()
    {
        if (target == null || target.Length < 3)
            return;

        Vector3 direction = (target[2].position - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * speed * Time.fixedDeltaTime;
        transform.position = newPosition;

        bs[0].speed = 2.5f;
        bs[1].speed = -2.5f;
        bs[2].speed = -2.5f;
        bs[3].speed = 2.5f;
        bs[4].speed = 2.5f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(Damage());
        }
    }

    IEnumerator Damage()
    {
        life--;
        lifeSlider.value = life;
        sr.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
        yield return new WaitForSeconds(0.1f);

        if (life <= (maxLife* 0.5f)&& life > (maxLife*0.5f)-1)
        {
            DestroyAllWithTag("EnemyBullet");
            mb.ChangeBackground(1);
        }
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
    void DestroyAllWithTag(string tag)
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }
}
