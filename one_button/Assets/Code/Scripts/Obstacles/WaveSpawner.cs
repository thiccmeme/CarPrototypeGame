using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints; //list of spawn points
    [SerializeField]
    private WaveSO[] waves; //list of wave scriptable objects
    private bool _isPaused = false; //is the wave spawner paused?
    GameObject obstacleToSpawn;
    
    [SerializeField]
    private GameObject[] collectables;
    [SerializeField]
    private float collectableSpawnChance = 0.5f; 

    private void Start()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            StartCoroutine(SpawnObstacle(waves[i], spawnPoints[i]));
        }
    }

    IEnumerator SpawnObstacle(WaveSO _wave, Transform spawnPoint)
    {
        while (true)
        {
            int obstacle = Random.Range(0, _wave.ObstaclesInWave.Length);
            Debug.Log("Wave: " + _wave + " Obstacle: " + obstacle);

            obstacleToSpawn = _wave.ObstaclesInWave[obstacle];
            Instantiate(obstacleToSpawn, spawnPoint.position, spawnPoint.rotation);

            // Random chance to spawn a collectable
            if (Random.value < collectableSpawnChance)
            {
                // Choose a random spawn point for the collectable
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject collectableToSpawn = collectables[Random.Range(0, collectables.Length)];
                Instantiate(collectableToSpawn, randomSpawnPoint.position, randomSpawnPoint.rotation);
            }
            
                
            yield return new WaitForSeconds(_wave.WaveDelay);
        }
    }
}
