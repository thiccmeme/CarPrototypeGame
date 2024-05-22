using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] protected Transform startPos;
    
    [SerializeField] protected Vector3 endPos;

    [SerializeField] protected PoolObject road;

    [SerializeField] private float Speed;

    public int roadCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RoadCheck());
    }
    public void SpawnRoad()
    {   
        //random which obstacle if 5 between 0-4 
        //random for speed of obstacles
        Debug.Log(road.name);
        Road newRoad = PoolManager.Instance.Spawn("Road").GetComponent<Road>();
        newRoad.transform.position = startPos.transform.position;
        roadCount++;
    }

    IEnumerator RoadCheck()
    {
        for (int i = 0; i <= roadCount; i++)
        {
            SpawnRoad();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
