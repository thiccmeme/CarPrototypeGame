using UnityEngine;

[CreateAssetMenu(fileName = "Wave SO", menuName = "ScriptableObjects/Wave")]
public class WaveSO : ScriptableObject
{
    [field: SerializeField]
    public ObstacleSO[] ObstaclesInWave { get; private set; } //list of obstacles to spawn

    [field: SerializeField]
    public float WaveDelay { get; private set; } //delay between each wave spawn

    [field: SerializeField]
    public float NumberToSpawn { get; private set; }
}