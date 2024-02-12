using System.Collections;
using UnityEngine;

public class Enemy : IInteractable
{
    [SerializeField] private BulletPool _pool;
    [SerializeField] private float _timeBetwenShots;

    private Coroutine _coroutine;
    private WaitForSeconds _wait;
    private bool _isShooting = true;

    private void OnEnable()
    {
        if (_isShooting == false)
            _coroutine = StartCoroutine(Shoot());
    }

    private void Awake()
    {
        _wait = new WaitForSeconds(_timeBetwenShots);
    }

    private void Start()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
        _isShooting = false;
    }

    private IEnumerator Shoot()
    {
        _isShooting = true;

        while (_isShooting)
        {
            _pool.GetObject(_pool.transform);
            yield return _wait;
        }
    }
}
