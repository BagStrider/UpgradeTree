using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        
        [SerializeField] private PlayerStatsConfig _stats;
        
        private Vector2 _movement = Vector2.zero;
        private bool _canMove = true;
        
        private void Update()
        {
            if(!_canMove) return;
            
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
            _movement = Vector2.ClampMagnitude(_movement, 1f);
        }

        private void FixedUpdate()
        {
            if (!_canMove) return;

            if (_movement == Vector2.zero)
            {
                _rb.linearVelocity = Vector2.zero;
                return;
            }

            _rb.linearVelocity = _movement * _stats.MovementSpeed;
        }
    }
}
