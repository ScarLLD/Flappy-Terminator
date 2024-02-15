using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : IInteractable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLife;

    private Rigidbody2D _rigidbody2D;
    private WaitForSeconds _timeToLiquidate;

    private void Awake()
    {
        _timeToLiquidate = new WaitForSeconds(_timeLife);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rigidbody2D.velocity = transform.right * _speed;
        StartCoroutine(Liquidate());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Disable();
    }

    private void OnDisable()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void Disable()
    {
        gameObject.SetActive(false);

    }

    private IEnumerator Liquidate()
    {
        bool isWork = true;

        while (isWork)
        {
            yield return _timeToLiquidate;
            Disable();
        }
    }
}
