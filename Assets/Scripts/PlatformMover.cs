using System;
using UnityEngine;

enum MoveDirection
{
    Left,
    Right
}

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.0f;
    [SerializeField] private float _moveDistance = 5.0f;
    [SerializeField] private MoveDirection _direction = MoveDirection.Right;
    
    private Vector2 _startPosition;
    private Vector2 _targetPosition;

    private Rigidbody2D _rigidbody;
    private bool _movingToTarget = true;

    private void Start()
    {
        _startPosition = transform.position;
        
        if(_direction == MoveDirection.Left) 
            _targetPosition = _startPosition + Vector2.left * _moveDistance;
        else
            _targetPosition = _startPosition + Vector2.right * _moveDistance;
        
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 target = _movingToTarget ? _targetPosition : _startPosition;
        Vector2 newPosition = Vector2.MoveTowards(_rigidbody.position, target, _moveSpeed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(newPosition);

        if (Vector2.Distance(_rigidbody.position, target) < 0.01f)
        {
            _movingToTarget = !_movingToTarget;
        }
    }
}
