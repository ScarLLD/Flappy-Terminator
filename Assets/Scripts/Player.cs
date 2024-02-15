using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCollisionHandler))]
[RequireComponent(typeof(PlayerShoot))]
public class Player : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerCollisionHandler _handler;
    private PlayerShoot _playerShoot;

    public event Action Dead;

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void Awake()
    {
        _handler = GetComponent<PlayerCollisionHandler>();
        _playerMover = GetComponent<PlayerMover>();
        _playerShoot = GetComponent<PlayerShoot>();
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _playerMover.Reset();
        _playerShoot.Reset();
    }

    public void SwitchInputStatus()
    {
        _playerMover.enabled = !_playerMover.enabled;
        _playerShoot.enabled = !_playerShoot.enabled;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        Dead?.Invoke();
    }        
}
