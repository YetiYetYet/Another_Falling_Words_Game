using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenFinish : MonoBehaviour
{
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
    }
}