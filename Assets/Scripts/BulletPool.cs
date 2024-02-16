using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletRotationZ;

    private List<Bullet> _pool;

    public void Reset()
    {
        var timePool = _pool.Where(bullet => bullet.gameObject.activeInHierarchy == true).ToList();

        for (int i = 0; i < timePool.Count; i++)
        {
            timePool[i].gameObject.SetActive(false);
        }
    }

    private void Awake()
    {
        _pool = new List<Bullet>();
    }  

    public void GetBullet(Transform transformStorage)
    {
        if (TryGetBullet(out Bullet bullet))
        {
            bullet.transform.SetPositionAndRotation
                (transformStorage.position, transform.rotation * Quaternion.Euler(0, 0, _bulletRotationZ)); ;
            bullet.gameObject.SetActive(true);
        }
        else
        {
            Bullet bulletStorage = Instantiate(_bulletPrefab, transform.position, transform.rotation);
            bulletStorage.transform.parent = _container;
            _pool.Add(bulletStorage);
        }
    }

    private bool TryGetBullet(out Bullet bullet)
    {
        bullet = _pool.FirstOrDefault(bullet => bullet.gameObject.activeInHierarchy == false);

        return bullet != null;
    }
}