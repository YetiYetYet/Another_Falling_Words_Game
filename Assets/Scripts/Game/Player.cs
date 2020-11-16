using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using Game;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 3;
    public int score;

    public int scorePerLetter = 10;

    public TextMeshProUGUI scoreText;
    public Transform healthLayout;

    public GameObject gameOverMenu;
    
    public GameObject bulletPrefab;
    public GameObject healthPrefabs;
    
    public WordManager wordManager;


    private void Start()
    {
        scoreText.text = "0";
        foreach (Transform child in healthLayout)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < life; i++)
        {
            Debug.Log("Add life");
            Instantiate(healthPrefabs, healthLayout);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Hurt();
        if(life < 1) Die();
        string word = other.GetComponent<WordDisplay>().originalText;
        wordManager.RemoveWord(word);
    }

    public void Hurt()
    {
        life--;
        Destroy(healthLayout.GetChild(0).gameObject);
    }

    public void Die()
    {
        AudioManager.Instance.Play("Damage");
        gameOverMenu.SetActive(true);
        Time.timeScale = 0.1f;
    }

    public void AddScore()
    {
        score += scorePerLetter;
        scoreText.text = score.ToString();
    }
    
    public void ShootBullet(Transform target)
    {
        AudioManager.Instance.Play("Shoot");
        
        GameObject bullet = Instantiate(bulletPrefab, transform);
        bullet.GetComponent<Bullet>().target = target.position;
        Vector3 dir = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
