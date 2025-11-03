using System;
using UnityEngine;

public class HealthPresenter : IDisposable
{
    [Zenject]
    private readonly HealthView _healthView;
    private readonly Player _player;
    
    private void HealthChangeHandler(float health)
    {
        _player.Health = health;
        _healthView.UpdateHealth(health);
    }

    public HealthPresenter()
    {
        _player.OnHealthChanged += HealthChangeHandler;
    }
    public void Dispose()
    {
        _player.OnHealthChanged -= HealthChangeHandler;
    }
}
