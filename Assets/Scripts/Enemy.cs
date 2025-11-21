using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _pointIndex = 0;
    private Vector3 _startPosition;
    private float _lastShot;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Transform[] _walkPoints;
    [SerializeField] private int _walkSpeed;
    
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletSpeed;
    
    void Start()
    {
        _startPosition = transform.position;
    }
    
    void Update()
    {
        Transform target = _walkPoints[_pointIndex];

        Vector3 startDir = (target.position - _startPosition).normalized;
        Vector3 currentDir = (target.position - transform.position).normalized;

        if (Time.time - 0.5f >= _lastShot)
        {
            _lastShot = Time.time;
            Bullet newBullet = Instantiate(_bullet).GetComponent<Bullet>();
            newBullet.Initiate(transform.position, currentDir, _bulletSpeed);
        }
        
        _spriteRenderer.flipX = currentDir.x < 0;
        
        transform.position += currentDir * _walkSpeed * Time.deltaTime;
        float dot = Vector3.Dot(startDir, currentDir);

        if (dot < 0f)
        {
            transform.position = target.position;

            _pointIndex++;
            if (_pointIndex >= _walkPoints.Length)
                _pointIndex = 0;

            _startPosition = transform.position;
        }
    }
}
