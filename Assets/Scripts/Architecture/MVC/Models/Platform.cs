using UnityEngine;

public sealed class Platform
{
    public Vector2 StartPosition
    {
        get;
        set;
    }

    public Vector2 TargetPosition
    {
        get;
        set;
    }
    
    public float MoveSpeed
    {
        get;
        set;
    } = 20.0f;

    public float MoveDistance
    {
        get;
        set;
    } = 115.0f;

    public MoveDirection Direction
    {
        get;
        set;
    } = MoveDirection.Right;

    public bool MovingToTarget
    {
        get;
        set;
    } = true;
}
