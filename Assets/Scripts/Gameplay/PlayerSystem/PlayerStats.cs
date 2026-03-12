using Gameplay.Player.Configs;

namespace Gameplay.Player
{
    public class PlayerStats
    {
        public float MovementSpeed => _movementSpeed;
        public float Damage => _damage;
        public float DamageMultiplier => _damageMultiplier;
        public float AdditionalAttacks => _additionalAttacks;
        public float MaxHealth => _maxHealth;
        
        private float _movementSpeed;
        private float _damage;
        private float _damageMultiplier;
        private float _additionalAttacks;
        private float _maxHealth;

        public PlayerStats(PlayerStatsConfig config)
        {
            _movementSpeed = config.MovementSpeed;
            _damage = config.Damage;
            _damageMultiplier = config.DamageMultiplier;
            _additionalAttacks = config.AdditionalAttacks;
            _maxHealth = config.MaxHealth;
        }

        public void SetDamage(float value) => _damage = value;
        public void SetDamageMultiplier(float value) => _damageMultiplier = value;
        public void SetAdditionalAttacks(float value) => _additionalAttacks = value;
        public void SetMovementSpeed(float value) => _additionalAttacks = value;
    }
}