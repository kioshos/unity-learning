using ProjectAssets.Scripts.Architecture.Interfaces;
using ProjectAssets.Scripts.Architecture.MVP.Player;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private HealthView _playerHealthView;
        
    private PlayerPresenter _playerPresenter;
    private HealthPresenter _playerHealthPresenter;

    private const float MAX_HEALTH_POINTS = 100.0f;

    // ReSharper disable Unity.PerformanceAnalysis
    public override void InstallBindings()
    {
        Container.Bind<PlayerAgent>().AsSingle().WithArguments(MAX_HEALTH_POINTS);
        
        Container.Bind<IPlayerView>().FromInstance(_playerView).AsSingle();
        Container.Bind<HealthView>().FromInstance(_playerHealthView).AsSingle();
        
        Container.Bind<PlayerPresenter>().AsSingle().NonLazy();
        Container.Bind<HealthPresenter>().AsSingle().NonLazy();
    }
    

    private void OnDestroy()
    {
        _playerPresenter?.Dispose();
        _playerHealthPresenter?.Dispose();
    }
}
