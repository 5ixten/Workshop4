using Unity.Mathematics;
using System.Linq;
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
    
    [SerializeField] private AudioClip[] _shotSounds;
    
    void Start()
    {
        _startPosition = transform.position;
    }
    
    void Update()
    {
        Transform target = _walkPoints[_pointIndex];

        Vector3 startDir = (target.position - _startPosition).normalized;
        Vector3 currentDir = (target.position - transform.position).normalized;

        if (Time.time - 1.5f >= _lastShot)
        {
            _lastShot = Time.time;
            Bullet newBullet = Instantiate(_bullet).GetComponent<Bullet>();
            newBullet.Initiate(transform.position, currentDir, _bulletSpeed);
            SoundHandler.Instance.PlaySound(
                _shotSounds[(int)UnityEngine.Random.Range(0, _shotSounds.Length)], transform.position, false
            );
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
