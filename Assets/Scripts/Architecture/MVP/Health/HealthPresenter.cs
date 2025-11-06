using System;
using UnityEngine;

public class HealthPresenter : IDisposable
{
  
    private readonly HealthView _healthView;
    private readonly PlayerAgent _playerAgent;
    
    private void HealthChangeHandler(float health)
    {
        _healthView.UpdateHealth(health);
    }

    public HealthPresenter()
    {
        _playerAgent.OnHealthChanged += HealthChangeHandler;
    }
    public void Dispose()
    {
        _playerAgent.OnHealthChanged -= HealthChangeHandler;
    }
}
