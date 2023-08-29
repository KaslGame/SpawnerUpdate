using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;
    private float _stopDistance = 1.5f;

    private void Update()
    {
        Move();
    }

    public void SetTarget(Transform targets)
    {
        _target = targets;
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, _target.position) > _stopDistance)
            transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
