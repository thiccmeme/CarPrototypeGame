using System.Collections;
using UnityEngine;

//Creating a new script for future changes.
public class Collectable : MonoBehaviour
{
    [SerializeField] private float _speed;
    Rigidbody2D _rb;
    [SerializeField] private float speedChangeCoeffecient;
    public float DestroyDelay = 2.0f;
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        StartCoroutine(MoveCar());
    }

    IEnumerator MoveCar()
    {
        while (true)
        {
            _rb?.MovePosition(_rb.position + Vector2.down * (_speed * Time.fixedDeltaTime)); //move obstacle\car based on its speed
            _speed = _speed + speedChangeCoeffecient;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null && col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collected");
            Destroy(this.gameObject); 
            //Add particle effect
        }
    }
    
    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }

}