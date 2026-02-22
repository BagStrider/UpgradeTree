using System;
using Core.Base;
using Core.Interfaces;
using UnityEngine;

namespace Gameplay.Combat
{
    public class EntityDetector : MonoBehaviour
    {
        public event Action<IEntity, Transform> OnDetected;

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<EntityProvider>(out var entityProvider))
            {
                OnDetected?.Invoke(entityProvider.Provide(), other.transform);
            }
        }
    }
}
