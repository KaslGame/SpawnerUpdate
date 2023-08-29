using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Transform> _targets = new List<Transform>();

    private List<Transform> _spawnPoints = new List<Transform>();

    private void Awake()
    {
        foreach (Transform spawPoint in transform)
            _spawnPoints.Add(spawPoint);
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        float secondsRespawn = 2f;
        var timeRespawn = new WaitForSeconds(secondsRespawn);

        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            Enemy newEnemy = Instantiate(_enemyPrefab, _spawnPoints[i].position, Quaternion.identity);
            newEnemy.SetTarget(_targets);

            yield return timeRespawn;
        }
    }
}
