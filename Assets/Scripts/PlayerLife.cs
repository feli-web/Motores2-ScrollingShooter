using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int maxLife;
    int life;
    public Slider lifeSlider;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        life = maxLife;
        lifeSlider.minValue = 0;
        lifeSlider.maxValue = maxLife;
        lifeSlider.value = life;
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            StartCoroutine(Damage());
            Invoke("RefreshSlider", 0.1F);
        }
    }
    public void RefreshSlider()
    {
        lifeSlider.value = life;
    }
    IEnumerator Damage()
    {
        life--;
        sr.color = Color.black;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.red;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
