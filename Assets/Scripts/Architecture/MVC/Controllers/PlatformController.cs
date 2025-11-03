using UnityEngine;

public class PlatformController : MonoBehaviour
{
    
    [SerializeField] private PlatformView _platformView;
    private readonly Platform _platform =  new Platform();
    void Start()
    {
        
        _platform.StartPosition =  _platformView.transform.position;
        _platform.TargetPosition = 
            _platform.Direction == MoveDirection.Right?_platform.StartPosition+Vector2.right*_platform.MoveDistance:
           _platform.StartPosition+Vector2.left*_platform.MoveDistance;

        _platformView.OnReachedTarget += OnPlatformReachedTargetHandler;
        print("AAAAAAAAAAAAAAAAAAAAAAAAAAa");
    }

    void FixedUpdate()
    {
        Vector2 target = _platform.MovingToTarget ? _platform.TargetPosition : _platform.StartPosition;
        _platformView.Move(target,_platform.MoveSpeed);
    }

    private void OnPlatformReachedTargetHandler()
    {
        _platform.MovingToTarget = !_platform.MovingToTarget;
        Vector2 target = _platform.MovingToTarget ? _platform.TargetPosition : _platform.StartPosition;
        _platformView.Move(target,_platform.MoveSpeed);
    }

    private void OnDestroy()
    {
        _platformView.OnReachedTarget -= OnPlatformReachedTargetHandler;
    }
}
