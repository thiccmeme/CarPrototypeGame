using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Road : PoolObject
{
    [SerializeField] private float Speed;

    [SerializeField]
    private Vector3 endpos;
    protected virtual void Start()
    {
        
    }
    

    protected void FixedUpdate()
    {
        transform.Translate(0, Speed, 0);
        if (this.transform.position == endpos)
        {
            float rand = Random.Range(-0.1f, -1.0f);
            Speed = rand;
            this.OnDeSpawn();
        }
    }
    
}
