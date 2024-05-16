using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float speed = 5.0f;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        //_rb.isKinematic = true; //
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
            _rb?.MovePosition(_rb.position + -Vector3.forward * speed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
