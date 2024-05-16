using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle SO", menuName = "ScriptableObjects/Obstacle")]
public class ObstacleSO : ScriptableObject
{
    public Texture2D ObstacleTexture2D;
    public float Speed; //obstacle move speed
}
