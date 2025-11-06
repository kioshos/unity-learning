using System;
using UnityEngine;

public sealed class PlayerAgent
{
    private float _health;
    public event Action<float> OnHealthChanged;

    public float Speed
    {
        get;
        set;

    } = 50.0f;
    
    public float JumpForce
    {
        get;
        set;
    } = 20.0f;

    public bool IsGrounded
    {
        get;
        set;

    } = true;

    public float Health
    {
        get {return _health;}
        set
        {
            _health = value;
            OnHealthChanged?.Invoke(_health);
        }
    }

    public PlayerAgent(float maxHealth)
    {
        _health = maxHealth;
    }
}
