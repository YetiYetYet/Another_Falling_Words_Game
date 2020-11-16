using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using TMPro;
using UnityEngine;

public class WordDisplay : MonoBehaviour
{
    public string originalText;
    public TextMeshProUGUI text;
    public float speed = 100f;
    public Transform target;

    public GameObject hurtParticlePrefabs;
    public GameObject dieParticleContainer;
    public Transform particleContainer;

    private void Start()
    {
        particleContainer = GameObject.FindGameObjectWithTag("ParticleContainer").transform;
    }

    private void Update()
    {
        MoveToTarget();
    }

    public void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void SetWord(string word)
    {
        text.text = word;
        originalText = word;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.green;
        GameObject hurtParticle = Instantiate(hurtParticlePrefabs, transform);
        hurtParticle.transform.SetParent(particleContainer);
    }

    public void RemoveWord()
    {
        GameObject dieParticle = Instantiate(hurtParticlePrefabs, transform);
        dieParticle.transform.SetParent(particleContainer);
        Destroy(gameObject);
    }
}
