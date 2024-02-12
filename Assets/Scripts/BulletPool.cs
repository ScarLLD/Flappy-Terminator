using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _gameObjectPrefab;

    private List<GameObject> _pool;

    public IEnumerable<GameObject> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new List<GameObject>();
    }

    public void GetObject(Transform transformStorage)
    {
        if (GetInactiveObjects().Count == 0)
        {
            var obj = Instantiate(_gameObjectPrefab, transformStorage.position, transformStorage.rotation);
            obj.transform.parent = _container;

            _pool.Add(obj);
        }
        else
        {
            GameObject objStorage = _gameObjectPrefab;

            foreach (var obj in _pool)
            {
                if (obj.activeInHierarchy == false)
                {
                    objStorage = obj;
                }
            }

            objStorage.transform.SetPositionAndRotation(transformStorage.position, transformStorage.rotation);
            objStorage.SetActive(true);
        }
    }

    public void Reset()
    {
        _pool.Clear();
    }

    private List<GameObject> GetInactiveObjects()
    {
        List<GameObject> obj = new List<GameObject>();

        obj = _pool.Where(obj => obj.activeInHierarchy == false).ToList();

        return obj;
    }
}