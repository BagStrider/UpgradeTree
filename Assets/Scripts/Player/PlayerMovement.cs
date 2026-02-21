using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        
        [SerializeField] private PlayerStatsConfig _stats;
        
        private Vector2 _movement = Vector2.zero;
        private Vector3 _cursorPosition = Vector3.zero;
        private bool _canMove = true;
        
        private UnityEngine.Camera _camera;
        private Quaternion _rotation;

        private void Awake()
        {
            _camera = UnityEngine.Camera.main;
        }

        private void Update()
        {
            if(!_canMove) return;
            //ArrowsKeyMovement();
            CursorMovement();
        }

        private void FixedUpdate()
        {
            if (!_canMove) return;

            if (_movement == Vector2.zero)
            {
                _rb.linearVelocity = Vector2.zero;
                return;
            }

            _rb.linearVelocity = _stats.MovementSpeed * _movement;
        }

        private void ArrowsKeyMovement()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
            _movement = Vector2.ClampMagnitude(_movement, 1f);
        }
        private void CursorMovement()
        {
            _cursorPosition =  _camera.ScreenToWorldPoint(Input.mousePosition);
            _cursorPosition.z = 0;
            _movement = (_cursorPosition - transform.position).normalized;
            _movement = Vector2.ClampMagnitude(_movement, 1f);

            if (Vector2.Distance(transform.position, _cursorPosition) < 0.25f)
            {
                _movement = Vector2.zero;
                return;
            }
            
            _rotation = Quaternion.LookRotation(Vector3.forward, _movement);
            transform.rotation = _rotation;
        }
    }
}
