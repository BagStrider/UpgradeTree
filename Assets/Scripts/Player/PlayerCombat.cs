using Entities;
using Entities.Enemy;
using Zenject;

namespace Player
{
    public class PlayerCombat : IInitializable
    {
        private PlayerStats _playerStats;
        private EntityDetector _detector;

        public PlayerCombat(PlayerStats playerStats, EntityDetector detector)
        {
            _playerStats = playerStats;
            _detector = detector;
        }

        public void Initialize()
        {
            _detector.OnDetected += OnPlayerDetectedEntityHandle;
        }
        
        private void OnPlayerDetectedEntityHandle(IEntity entity)
        {
            entity.TakeDamage(_playerStats.Damage * _playerStats.DamageMultiplier);
        }
    }
}