using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject boss;
    public GameObject player;

    public Image result;
    public TextMeshProUGUI resultText;


    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        player = GameObject.FindGameObjectWithTag("Player");
        result.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
        {
            DestroyAllWithTag("EnemyBullet");
            GameOver("You Won!!");

        }
        if (player == null)
        {
            GameOver("You Lost");
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
    void GameOver(string a)
    {
        Time.timeScale = 0;
        result.gameObject.SetActive(true);
        resultText.text = a;
    }

}
