using System;
using UnityEngine;

namespace Gameplay.PlayerSystem
{
    public class PlayerDetector : MonoBehaviour
    {
        public event Action<Core.Player, Transform> OnDetected;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<PlayerProvider>(out var playerProvider))
            {
                OnDetected?.Invoke(playerProvider.Provide() as Core.Player, other.transform);
            }
        }
    }
}