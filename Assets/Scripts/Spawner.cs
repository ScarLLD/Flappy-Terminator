using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private EnemyPool _pool;

    private void Start()
    {
        StartCoroutine(GenerateEnemys());
    }

    private IEnumerator GenerateEnemys()
    {
        var wait = new WaitForSeconds(_delay);

        bool isSpawning = true;

        while (isSpawning)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var enemy = _pool.GetObject();

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
