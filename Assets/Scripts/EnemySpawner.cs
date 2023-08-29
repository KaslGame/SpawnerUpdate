using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float secondsRespawn;

    private List<Transform> _spawnPoints;

    private void Awake()
    {
        _spawnPoints = new List<Transform>(transform.childCount);

        foreach (Transform spawPoint in transform)
            _spawnPoints.Add(spawPoint);
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var timeRespawn = new WaitForSeconds(secondsRespawn);

        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            Enemy newEnemy = Instantiate(_prefab, _spawnPoints[i].position, Quaternion.identity);
            newEnemy.SetTarget(_target);

            yield return timeRespawn;
        }
    }
}
