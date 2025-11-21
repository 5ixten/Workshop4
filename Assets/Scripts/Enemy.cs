using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _pointIndex = 0;
    private Vector3 _startPosition;
    
    [SerializeField] private Transform[] _walkPoints;
    [SerializeField] private int _walkSpeed;
    
    
    void Start()
    {
        _startPosition = transform.position;
    }
    
    void Update()
    {
        Transform target = _walkPoints[_pointIndex];

        Vector3 startDir = (target.position - _startPosition).normalized;
        Vector3 currentDir = (target.position - transform.position).normalized;
        
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
