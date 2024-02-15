using System.Collections;
using UnityEngine;

public class Enemy : IInteractable
{
    [SerializeField] private float _timeBetwenShots;
    [SerializeField] private  string _bulletPoolTag;

    private BulletPool _pool;
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
        _pool = GameObject.FindWithTag(_bulletPoolTag).GetComponent<BulletPool>();
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
        _isShooting = false;
        StopCoroutine(_coroutine);
    }

    private IEnumerator Shoot()
    {
        _isShooting = true;

        while (_isShooting)
        {
            _pool.GetObject(transform);
            yield return _wait;
        }
    }
}
