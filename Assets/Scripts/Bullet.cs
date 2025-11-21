using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector3 _direction;
    private Vector3 _startPosition;
    
    private float _speed;
    private bool _initiated = false;

    public void Initiate(Vector3 position, Vector3 direction, float speed)
    {
        _startPosition = position;
        _direction = direction;
        _speed = speed;
        _initiated = true;
        
        transform.position = position;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!_initiated) return;
        _rb.linearVelocity = _direction * _speed;
        
        float distanceTraveled = (transform.position - _startPosition).magnitude;
        if (distanceTraveled > 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player)
        {
            GameHandler.Instance.TakeDamage(1);
        }
        Destroy(gameObject);
    }
}
