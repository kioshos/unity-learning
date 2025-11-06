using System;

namespace ProjectAssets.Scripts.Architecture.Interfaces
{
    public interface IPlayerView
    {
        public event Action<float> OnInputChanged;
        public event Action OnJumped;
        public event Action OnLanded;
        public event Action OnObstacleHit;
        public void Move(float horizontal, float speed);
        public void Jump(float jumpForce);
    }
}