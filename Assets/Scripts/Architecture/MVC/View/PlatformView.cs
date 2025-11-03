using System;
using UnityEngine;

public class PlatformView : MonoBehaviour
{
    public event Action OnReachedTarget;

    [SerializeField] private Rigidbody2D _rigidbody;
    private Vector2 _currentTarget;
    

    public void Move(Vector2 target, float speed)
    {
        print("???????????????????????????????????????????????");
        _currentTarget = target;
        Vector2 newPosition = Vector2.MoveTowards(_rigidbody.position, target,
            speed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(newPosition);
        
        if (Vector2.Distance(_rigidbody.position, target) < 0.01f)
        {
            OnReachedTarget?.Invoke();
            
        }
    }
}
