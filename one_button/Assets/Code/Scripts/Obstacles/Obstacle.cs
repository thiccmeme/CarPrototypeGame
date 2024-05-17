using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ObstacleSO obstacle;
    Rigidbody _rb;

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
            _rb?.MovePosition(_rb.position + -Vector3.forward * obstacle.Speed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
