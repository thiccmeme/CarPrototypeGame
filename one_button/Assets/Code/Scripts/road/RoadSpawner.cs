using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] protected Transform startPos;

    [SerializeField] protected PoolObject road;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRoad();
    }

    protected void SpawnRoad()
    {   
        Debug.Log(road.name);
        Road newRoad = PoolManager.Instance.Spawn("Road").GetComponent<Road>();
        newRoad.transform.position = startPos.transform.position;
    }

    private void FixedUpdate()
    {
        // if number of roads is less than or equal to 2 then spawn new road.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
