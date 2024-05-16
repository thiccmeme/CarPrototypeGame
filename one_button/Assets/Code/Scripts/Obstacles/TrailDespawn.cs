using UnityEngine;

public class TrailDespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstable")
        {
            Destroy(other.gameObject);
        }

    }
}