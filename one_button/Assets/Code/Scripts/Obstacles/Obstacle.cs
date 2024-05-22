using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _speed;
    Rigidbody2D _rb;
    [SerializeField] private float speedChangeCoeffecient;

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
            _rb?.MovePosition(_rb.position + Vector2.down * _speed * Time.fixedDeltaTime); //move obstacle\car based on its speed
            _speed = _speed + speedChangeCoeffecient;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject); //destroy obstacle when triggered with player
        }
    }
}
