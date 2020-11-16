using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 target;
    public float speed;

    public void Update()
    {
        if (target == transform.position)
        {
            Destroy(gameObject);
        }
        MoveToTarget();
    }

    public void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    
}
