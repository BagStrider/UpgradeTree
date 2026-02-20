using System;
using UnityEngine;

namespace Entities.Enemy
{
    public class EntityDetector : MonoBehaviour
    {
        public event Action<IEntity> OnDetected;

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<EntityProvider>(out var entityProvider))
            {
                OnDetected?.Invoke(entityProvider.Provide());
            }
        }
    }
}
