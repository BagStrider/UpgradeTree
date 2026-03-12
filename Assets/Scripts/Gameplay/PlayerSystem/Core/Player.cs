using Core.Base;
using Core.Interfaces;
using Gameplay.Player.Configs;

namespace Gameplay.PlayerSystem.Core
{
    public class Player : IEntity
    {
        public Health Health => _health;
        
        private Health _health;

        public Player(PlayerStatsConfig config)
        {
            _health = new Health(config.MaxHealth, config.MaxHealth);
        }
        
        public void TakeDamage(float damage)
        {
            _health.Decrease(damage);
        }
    }
}