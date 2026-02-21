using System;
using Cysharp.Threading.Tasks;
using Entities;
using Entities.Enemy;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerCombat : IInitializable, IDisposable
    {
        private PlayerStats _playerStats;
        private EntityDetector _detector;
        private PlayerMovement _playerMovement;
        private bool _isKnocked = false;
        
        public PlayerCombat(PlayerStats playerStats, EntityDetector detector, PlayerMovement playerMovement)
        {
            _playerStats = playerStats;
            _detector = detector;
            _playerMovement = playerMovement;
        }

        public void Initialize()
        {
            _detector.OnDetected += OnPlayerDetectedEntityHandle;
        }
        
        private void OnPlayerDetectedEntityHandle(IEntity entity, Transform transform)
        {
            if(_isKnocked) return;
            
            entity.TakeDamage(_playerStats.Damage * _playerStats.DamageMultiplier);
            Vector3 direction = (_playerMovement.transform.position - transform.position).normalized;
            
            KnockbackPlayer(.5f, direction ,200f).Forget();
        }

        private  async UniTaskVoid KnockbackPlayer(float seconds, Vector3 direction,  float knockbackPower)
        {
            _playerMovement.LockMovement(true);
            _playerMovement.Knockback(direction, knockbackPower);
            _isKnocked = true;
            
            await UniTask.WaitForSeconds(seconds);
            
            _playerMovement.LockMovement(false);
            _isKnocked = false;
        }

        public void Dispose()
        {
            _detector.OnDetected -= OnPlayerDetectedEntityHandle;
        }
    }
}