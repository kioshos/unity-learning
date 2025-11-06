using System;
using UnityEngine;

namespace ProjectAssets.Scripts.Architecture.MVP.Player
{
    public class PlayerView : MonoBehaviour
    {
        public event Action<float> OnInputChanged;
        public event Action OnJumped;
        public event Action OnLanded;
        public event Action OnObstacleHit;
        
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private float _horizontalInput = 0;

        private void Update()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            OnInputChanged?.Invoke(_horizontalInput);
                
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJumped?.Invoke(); 
            }
        }

        public void Move(float horizontalInput, float speed)
        {
            _rigidbody2D.linearVelocityX = horizontalInput * speed;
        }

        public void Jump(float jumpForce)
        {
           _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
            {
                OnLanded?.Invoke();
            }
            
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                OnObstacleHit?.Invoke();
            }
        }
    }
}