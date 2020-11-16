using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class WordDelay : MonoBehaviour
{
    // Start is called before the first frame update
    public WordManager wordManager;

    public float wordDelay = 1.5f;
    private float _nextWordTime;
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= _nextWordTime)
        {
            wordManager.AddRandomWord();
            _nextWordTime = Time.time + wordDelay;
            wordDelay *= 0.99f;
        }
    }
}
