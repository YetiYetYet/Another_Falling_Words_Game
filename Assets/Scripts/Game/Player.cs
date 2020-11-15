using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 3;
    public WordManager wordManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hurt");
        life--;
        if(life < 1) Die();
        string word = other.GetComponent<WordDisplay>().originalText;
        wordManager.RemoveWord(word);
    }

    public void Die()
    {
        // Die
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
