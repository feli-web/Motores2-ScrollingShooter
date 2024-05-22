using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingBackground : MonoBehaviour
{
    public float moveSpeed;
    private SpriteRenderer sr;
    public Sprite[] backgrounds;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = backgrounds[0];
    }

    void Update()
    {
        sr.material.mainTextureOffset = new Vector2(0f, Time.realtimeSinceStartup * -moveSpeed * Time.timeScale);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
    public void ChangeBackground(int c)
    {
        sr.sprite = backgrounds[c];
    }

}
