using System;

namespace ProjectAssets.Scripts.Architecture.MVP.Player
{
    public class PlayerPresenter : IDisposable
    {
        private readonly PlayerView _playerView;
        private readonly PlayerAgent _playerAgent;
        
        public PlayerPresenter( PlayerAgent playerAgent, PlayerView playerView)
        {
            _playerAgent = playerAgent;
            _playerView = playerView;

            _playerView.OnInputChanged += HandleMovement;
            _playerView.OnJumped += HandleJump;
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
        public void Dispose()
        {
           _playerView.OnInputChanged -= HandleMovement;
           _playerView.OnJumped -= HandleJump;
        }
    }
}