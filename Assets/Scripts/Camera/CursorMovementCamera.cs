using UnityEngine;

namespace Camera
{
    public class CameraCursorMovement : MonoBehaviour
    {
        [SerializeField] private float _dragSpeed = 1f;

        [SerializeField] private float[] _zoomSteps = 
        {
            2f, 4f, 6f, 8f, 10f
        };

        [SerializeField] private float _zoomSmoothTime = 0.15f;

        private UnityEngine.Camera _cam;
        private Vector3 _lastMouseWorldPos;
        private int _currentZoomIndex;
        private float _zoomVelocity;

        void Awake()
        {
            _cam = UnityEngine.Camera.main;
            _currentZoomIndex = 0;
            _cam.orthographicSize = _zoomSteps[_currentZoomIndex];
        }

        void Update()
        {
            HandleDrag();
            HandleZoomInput();
            SmoothZoom();
        }

        void HandleDrag()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastMouseWorldPos = GetMouseWorldPosition();
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 currentMouseWorldPos = GetMouseWorldPosition();
                Vector3 delta = _lastMouseWorldPos - currentMouseWorldPos;

                transform.position += delta * _dragSpeed;
            }
        }
        void HandleZoomInput()
        {
            float scroll = Input.mouseScrollDelta.y;

            if (scroll > 0 && _currentZoomIndex > 0)
            {
                _currentZoomIndex--;
            }
            else if (scroll < 0 && _currentZoomIndex < _zoomSteps.Length - 1)
            {
                _currentZoomIndex++;
            }
        }
        void SmoothZoom()
        {
            float targetZoom = _zoomSteps[_currentZoomIndex];

            _cam.orthographicSize = Mathf.SmoothDamp(
                _cam.orthographicSize,
                targetZoom,
                ref _zoomVelocity,
                _zoomSmoothTime
            );
        }
        
        Vector3 GetMouseWorldPosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -_cam.transform.position.z;
            return _cam.ScreenToWorldPoint(mousePos);
        }
    }
}
