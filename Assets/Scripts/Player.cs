using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{   
    private PlayerMover _playerMover;
    private PlayerCollisionHandler _handler;

    public event Action GameOver;

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void Awake()
    {
        _handler = GetComponent<PlayerCollisionHandler>();
        _playerMover = GetComponent<PlayerMover>();
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
        _playerMover.Reset();
    }
}
