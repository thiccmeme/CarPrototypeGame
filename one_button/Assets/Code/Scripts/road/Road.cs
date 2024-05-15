using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Road : PoolObject
{
    [SerializeField] private float Speed;
    [SerializeField] protected Vector3 endPos;

    protected virtual void Start()
    {

    }
    

    protected void FixedUpdate()
    {
        transform.Translate(0, Speed, 0);
        if (transform.position == endPos)
        {
            this.OnDeSpawn();
            
        }
        
    }
    
}
