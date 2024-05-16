using System.Collections;
using UnityEngine;

public class TrailSpawner : MonoBehaviour
{
    [SerializeField]
    Transform spawnLocation;
    [SerializeField]
    Obstacle obstacle;
    [SerializeField]
    float spawnTime = 5;

    private void Start()
    {
        StartCoroutine(SpawnBall());
    }

    IEnumerator SpawnBall()
    {
        while (true)
        {
            //instantiate ball based on spawnLocation position and rotation
            Instantiate(obstacle, spawnLocation.position, Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(spawnTime);
        }
    }
}