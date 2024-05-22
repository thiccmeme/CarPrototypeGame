using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : PoolObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
       Invoke ("OnDeSpawn", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
