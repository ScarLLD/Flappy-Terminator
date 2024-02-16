using System.Collections;
using UnityEngine;

public class Enemy : IInteractable
{
    [SerializeField] private float _timeBetwenShots;
    [SerializeField] private string _bulletPoolTag;

    private BulletPool _bulletPool;
    private Coroutine _shootCoroutine;
    private WaitForSeconds _wait;
    private bool _isShooting = true;

    private void Awake()
    {
        _wait = new WaitForSeconds(_timeBetwenShots);
    }

    private void OnEnable()
    {
        if (_isShooting == false)
            _shootCoroutine = StartCoroutine(Shoot());
    }

    private void Start()
    {
        _shootCoroutine = StartCoroutine(Shoot());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _isShooting = false;
        StopCoroutine(_shootCoroutine);
    }

    public void InitPool(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    private IEnumerator Shoot()
    {
        _isShooting = true;

        while (_isShooting)
        {
            _bulletPool.GetBullet(transform);
            yield return _wait;
        }
    }
}
