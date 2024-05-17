using UnityEngine;

public class WaveDespawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            Destroy(col.gameObject);
        }
    }
}