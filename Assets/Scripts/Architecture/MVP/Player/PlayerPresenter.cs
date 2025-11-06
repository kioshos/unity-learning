using System;
using ProjectAssets.Scripts.Architecture.Interfaces;
using Zenject;

namespace ProjectAssets.Scripts.Architecture.MVP.Player
{
    public class PlayerPresenter : IDisposable
    {
        [Inject]
        private readonly IPlayerView _playerView;
        [Inject]
        private readonly PlayerAgent _playerAgent;
        
        public PlayerPresenter( PlayerAgent playerAgent, IPlayerView playerView)
        {
            _playerAgent = playerAgent;
            _playerView = playerView;

            _playerView.OnInputChanged += HandleMovement;
            _playerView.OnJumped += HandleJump;
            _playerView.OnLanded += HandleLanded;
            _playerView.OnObstacleHit += ObstacleHandle;
        }

        private void HandleMovement(float direction)
        {
            if (_playerAgent.IsGrounded)
            {
                _playerView.Move(direction, _playerAgent.Speed);
            }
        }

        private void HandleJump()
        {
            if (_playerAgent.IsGrounded)
            {
                _playerAgent.IsGrounded = false;
                
                _playerView.Jump(_playerAgent.JumpForce);
            }
        }

        private void HandleLanded()
        {
            _playerAgent.IsGrounded = true;
        }

        private void ObstacleHandle()
        {
            _playerAgent.Health -= 15;
        }
        public void Dispose()
        {
           _playerView.OnInputChanged -= HandleMovement;
           _playerView.OnJumped -= HandleJump;
           _playerView.OnLanded -= HandleLanded;
           _playerView.OnObstacleHit -= ObstacleHandle;
        }
    }
}