using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Bullet _bulletPrefab;

    private List<Bullet> _pool;

    private void Awake()
    {
        _pool = new List<Bullet>();
    }

    public void GetObject(Transform transform)
    {
        if (TryGetBullet(out Bullet bullet))
        {
            bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
            bullet.gameObject.SetActive(true);
        }
        else
        {
            Bullet bulletStorage = Instantiate(_bulletPrefab, transform.position, transform.rotation);
            bulletStorage.transform.parent = _container;
            _pool.Add(bulletStorage);

        }
    }

    public void Reset()
    {
        _pool.Where(bullet => bullet.gameObject.activeInHierarchy == true).Select
            (bullet => { bullet.gameObject.SetActive(false); return bullet; });
    }

    private bool TryGetBullet(out Bullet bullet)
    {
        bullet = _pool.FirstOrDefault(bullet => bullet.gameObject.activeInHierarchy == false);

        return bullet != null;
    }
}