using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Enemy _enemyPrefab;

    private List<Enemy> _pool;

    public void Reset()
    {
        var timePool = _pool.Where(enemy => enemy.gameObject.activeInHierarchy == true).ToList();

        for (int i = 0; i < timePool.Count; i++)
        {
            timePool[i].gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        _pool = new List<Enemy>();
    }

    public void GetEnemy(Vector3 spawnPoint)
    {
        if (TryGetEnemy(out Enemy enemy))
        {
            enemy.transform.position = spawnPoint;
            enemy.gameObject.SetActive(true);

        }
        else
        {
            Enemy enemyStorage = Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity);
            enemyStorage.InitPool(_bulletPool);

            _pool.Add(enemyStorage);

            enemyStorage.transform.parent = _container;
            enemyStorage.gameObject.SetActive(true);
        }
    }

    private bool TryGetEnemy(out Enemy enemy)
    {
        enemy = _pool.FirstOrDefault(enemy => enemy.gameObject.activeInHierarchy == false);
        return enemy != null;
    }
}