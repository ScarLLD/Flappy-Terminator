using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private BulletPool _pool;

    private PlayerMover _birdMover;
    private ScoreCounter _scoreCounter;
    private PlayerCollisionHandler _handler;

    public event Action GameOver;

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _handler = GetComponent<PlayerCollisionHandler>();
        _birdMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _pool.GetObject(transform);
        }
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        Debug.Log("collision here");

        GameOver?.Invoke();
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _birdMover.Reset();
    }
}
