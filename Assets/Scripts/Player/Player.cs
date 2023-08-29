using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _pointContainer;
    [SerializeField] private float _speed;

    private List<Transform> _points;
    private float _stopDistance = 1.5f;
    private int _currentPoint;

    private void Awake()
    {
        _points = new List<Transform>(_pointContainer.childCount);

        foreach (Transform point in _pointContainer)
            _points.Add(point);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_points.Count - 1 >= _currentPoint)
        {
            if (Vector2.Distance(transform.position, _points[_currentPoint].position) > _stopDistance)
                transform.position = Vector2.MoveTowards(transform.position, _points[_currentPoint].position, _speed * Time.deltaTime);
            else
                _currentPoint++;
        }
        else
        {
            _currentPoint = 0;
        }
    }
}