using System;
using UnityEngine;
using Zenject;

public class HealthPresenter : IDisposable
{
    [Inject]
    private readonly HealthView _healthView;
    [Inject]
    private readonly PlayerAgent _playerAgent;

    public HealthPresenter(PlayerAgent playerAgent,  HealthView healthView)
    {
        _playerAgent = playerAgent;
        _healthView = healthView;
        _playerAgent.OnHealthChanged += HealthChangeHandler;
        
    }
    private void HealthChangeHandler(float health)
    {
        _healthView.UpdateHealth(health);
    }
    public void Dispose()
    {
        _playerAgent.OnHealthChanged -= HealthChangeHandler;
    }
}
