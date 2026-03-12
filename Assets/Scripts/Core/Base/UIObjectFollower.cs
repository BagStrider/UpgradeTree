using System;
using UnityEngine;

namespace Core.Base
{
    public class UIObjectFollower : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset = new  (0f, 1f, 0f);
        
        private Transform _followTarget;

        public void SetTarget(Transform target)
        {
            _followTarget = target;
        }
        
        private void Update()
        {
            if(_followTarget ==  null) return;
            
            transform.position = Camera.main.WorldToScreenPoint(_followTarget.position + _offset);
        }
    }
}