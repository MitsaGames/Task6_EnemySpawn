using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnTime = 2.0f;

    private SpawnPoint[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitToNextSpawn = new WaitForSeconds(_spawnTime);

        while (true)
        {
            for (int spawnPointIndex = 0; spawnPointIndex < _spawnPoints.Length; spawnPointIndex++)
            {
                var currentSpawnPoint = _spawnPoints[spawnPointIndex];

                if (_enemyPrefab)
                {
                    Instantiate(_enemyPrefab, currentSpawnPoint.transform.position, Quaternion.identity);
                }

                yield return waitToNextSpawn;
            }
        }
    }
}
