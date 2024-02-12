using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : IInteractable
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLife;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rigidbody2D.velocity = transform.right * _speed;
        Invoke(nameof(Disable), _timeLife);
    }

    private void OnDisable()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
