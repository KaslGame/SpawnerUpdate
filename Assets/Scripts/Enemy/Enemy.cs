using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private List<Transform> _targets;
    private float _stopDistance = 1.5f;
    private int _currentTargetIndex = 0;

    private void Update()
    {
        if (_targets.Count != 0)
            Move();
    }

    public void SetTarget(List<Transform> targets)
    {
        _targets = targets;
    }

    private void Move()
    {
        if (_targets.Count - 1 >= _currentTargetIndex)
        {
            if (Vector2.Distance(transform.position, _targets[_currentTargetIndex].position) > _stopDistance)
                transform.position = Vector2.MoveTowards(transform.position, _targets[_currentTargetIndex].position, _speed * Time.deltaTime);
            else
                _currentTargetIndex++;
        }
    }
}
