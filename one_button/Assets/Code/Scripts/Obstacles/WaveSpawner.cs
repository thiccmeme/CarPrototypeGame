using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints; //list of spawn points

    public WaveSO[] waves; //list of wave scriptable objects

    private WaveSO _currentWave;
    private int _waveCount = 0;
    private float _waveDelay; //delay between each wave spawn
    private bool _isPaused = false; //is the wave spawner paused?
    GameObject obstacleToSpawn;

    private void Awake()
    {
        _currentWave = waves[_waveCount];
        _waveDelay = _currentWave.WaveDelay;
        _waveDelay = 1;
    }

    private void Update()
    {
        if (_isPaused) return;

        if (Time.time >= _waveDelay)
        {
            SpawnWave();
            WaveCount();

            _waveDelay = Time.time + _currentWave.WaveDelay;
        }
    }

    private void SpawnWave()
    {

        for (int i = 0; i < _currentWave.NumberToSpawn; i++)
        {
            int obstacle = Random.Range(0, _currentWave.ObstaclesInWave.Length);
            int spawnPoint = Random.Range(0, spawnPoints.Length);

            obstacleToSpawn = _currentWave.ObstaclesInWave[obstacle];
            
            Instantiate(obstacleToSpawn, spawnPoints[spawnPoint].position, spawnPoints[spawnPoint].rotation);
        }
    }

    private void WaveCount()
    {
        if (_waveCount + 1 < waves.Length)
        {
            _waveCount++;
            _currentWave = waves[_waveCount];
        }
        //else
        //{
        //    _isPaused = true;
        //}
    }
}
