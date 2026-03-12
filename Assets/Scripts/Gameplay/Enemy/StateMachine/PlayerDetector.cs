using System;
using Gameplay.PlayerSystem;
using UnityEngine;

namespace Gameplay.Enemy.StateMachine
{
    public class PlayerDetector : MonoBehaviour
    {
        public event Action<PlayerCollisionData> OnPlayerDetected;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerProvider>(out var playerProvider))
            {
                var player = playerProvider.Provide() as PlayerSystem.Core.Player;
                
                var data = new PlayerCollisionData(player, other.transform);
                
                OnPlayerDetected?.Invoke(data);
            }
        }
    }
}